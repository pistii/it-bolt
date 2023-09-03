<template >
  <div>
   <div style="text-align: left">
     <h4 class="totalText">Összesen: <b>{{ totalItem }}</b></h4>
     <button class=" deselectBtn btn success btn-success btn-outline-success me-3 mt-3 mb-3"
       @click="saveChanges">Mentés</button>
   </div>
 </div>

 <div class="pag">
   <span class="oldalak">
     Oldalak:
   </span>
   <select v-on:change="onPageSizeChanged()" class="form-select" id="page-size">
     <option value="10" selected="">10</option>
     <option value="100">100</option>
     <option value="500">500</option>
     <option value="1000">1000</option>
   </select>
 </div>

 <div style="height: 80%">
   <div style="display: flex; flex-direction: row; height: 70%;">
     <div style=" overflow: hidden; flex-grow: 1">
       <ag-grid-vue class="ag-theme-alpine table-responsive table" style="height: 678px; text-align: left;" :columnDefs="columnDefs.value"
         :rowData="rowData.value" :defaultColDef="defaultColDef" :pagination="true" rowSelection="multiple"
         animateRows="true" @grid-ready="onGridReady" :paginationPageSize="paginationPageSize" :localeText="localeText"
         @cell-editing-started="onCellEditingStarted" @cell-editing-stopped="onCellEditingStopped"
         :frameworkComponents="frameworkComponents">
       </ag-grid-vue>
     </div>
   </div>
 </div>
</template>


<script>
//import NavBar from '../components/NavBar2.vue';
import axios from 'axios'
import { AgGridVue } from "ag-grid-vue3";  // the AG Grid Vue Component
import { reactive, onMounted, ref } from "vue";
import "ag-grid-community/styles/ag-grid.css"; // Core grid CSS, always needed
import "ag-grid-community/styles/ag-theme-alpine.css"; // Optional theme CSS
import "../assets/main.css";
import { AG_GRID_LOCALE_HU } from "../js/locale.hu.js";
//import { useDateFormat } from '@vueuse/core'
import { CheckboxCellRenderer } from "../js/checkbox-cell-renderer.js";

const collection = [];
var totalItem = ref(null);

//for validation
const minBoltNeve = 3;
const minBoltCime = 3;
const minNyitvatartas = 3;
const checked= ref(null);
export default {
 name: "App",
 components: {
   AgGridVue,
   'ag-grid-vue': AgGridVue,
 },
 methods: {
   onCellEditingStarted(event) {
     //startedEditing = event.value;
     //startValue = event.value
     console.log('cellEditingStarted ' + event);
   },
   onCellEditingStopped(event) { //validálás

     if (event.column.colId == 'bolt_neve')  {
       if (event.newValue.length > minBoltNeve) {
         console.log(event)
         collection.push(event);
       }
     }

     if (event.column.colId == 'bolt_cime')  {
       if (event.newValue.length > minBoltCime) {
         console.log(event)
         collection.push(event);
       }
     }


     if (event.column.colId == 'nyitvatartasi_ido')  {
       if (event.newValue.length > minNyitvatartas) {
         console.log(event)
         collection.push(event);
       }
     }


   },
 },
 
 
   created() {
     this.localeText = AG_GRID_LOCALE_HU;  

     this.paginationPageSize = 10;

     
     this.frameworkComponents = {
       checkboxRenderer: CheckboxCellRenderer
     };
 },
 setup() {
   const gridApi = ref(null); // Optional - for accessing Grid's API
   // Obtain API from grid's onGridReady event
   const onGridReady = (params) => {
     gridApi.value = params.api;
   };

   const defaultColDef = {
     sortable: true,
     editable: true,
     flex: 1,
     filter: true,
     pagination: true,
     resizable: true,
     
     wrapHeaderText: true,
     autoHeaderHeight: true,
   };

   // Example load data from server
   onMounted(() => {
     axios.get('http://localhost:5000/api/boltok')
       .then(result => totalItem.value = result.data.totalItems);
     axios.get('http://localhost:5000/api/boltok')
       .then(result => rowData.value = result.data.data);

   });

   const rowData = reactive({}); // Set rowData to Array of Objects, one Object per Row
   
   
   const columnDefs = ref({
     value: [
       {
         headerName: 'bolt neve', field: "bolt_neve", sortable: true,
         cellStyle : params => params.value.length <= minBoltNeve ? {backgroundColor : 'red'} : {backgroundColor : 'transparent'},
         wrapText: true,
         autoHeight: true,
         filterParams: {
           filterOptions: ['contains', 'startsWith', 'endsWith'],
           defaultOption: 'contains'
         }
       },
       {
         headerName: 'bolt címe', field: "bolt_cime", sortable: true, 
         cellStyle : params => params.value.length <= minBoltCime ? {backgroundColor : 'red'} : {backgroundColor : 'transparent'},
         wrapText: true,
         autoHeight: true,
         filterParams: {
           filterOptions: ['contains', 'startsWith', 'endsWith'], sortable: true,
           defaultOption: 'contains'
         },
       },
       {
         headerName: "nyitvatartási idő", field: "nyitvatartasi_ido", 
         cellStyle : params => params.value.length <= minNyitvatartas ? {backgroundColor : 'red'} : {backgroundColor : 'transparent'},
         wrapText: true,
         autoHeight: true,
         sortable: true, editable : true,
         
       }
     ]
   })


   return {
     onGridReady,
     defaultColDef,
     columnDefs,
     rowData,
     totalItem,
     checked,
     saveChanges: () => { //Send put request for the server
       var newvv = "";
       console.log(checked.value);
       
       collection.forEach(element => {
         if (element.oldValue != element.newValue) {
         newvv +=  element.data.bolt_neve + " : " +
           element.oldValue + " => " + element.newValue + "\n"
         }
       })
     
       if(collection.length>0) {
         if (confirm('Módosítások mentése?\n' + newvv) === true) {
           collection.forEach(PutToDatabase => {
             console.log(PutToDatabase.data.boltID)
             axios({
               method: 'put',
               url: 'api/boltok/' + PutToDatabase.data.boltID,
               data: {
                 boltID: PutToDatabase.data.boltID,
                 bolt_neve: PutToDatabase.data.bolt_neve,
                 bolt_cime: PutToDatabase.data.bolt_cime,
                 nyitvatartasi_ido: PutToDatabase.data.nyitvatartasi_ido
               }
             })
           });
         }
       }
     },
     updateData: (data) => {
       this.rowData = data;
       
     },
     onPageSizeChanged() {
     var value = document.getElementById('page-size').value;
       gridApi.value.paginationSetPageSize(Number(value));
       console.log(Number(value));
     },


   };
 }
};
</script>

<style>
.ag-theme-alpine {
 --ag-foreground-color: rgb(210, 222, 235);
 --ag-background-color: rgb(22, 54, 66);
 --ag-header-foreground-color: rgb(255, 255, 255);
 --ag-header-background-color: rgba(63, 64, 95, 0.308);
 --ag-odd-row-background-color: rgba(0, 0, 0, 0.073);
 --ag-font-family: monospace;
 --ag-card-shadow: 0 1px 4px 1px rgba(20, 84, 188, 0.986);
 --ag-popup-shadow: var(--ag-card-shadow);

 --ag-card-radius: 10px;
   --ag-card-shadow: 0 10px 40px rgb(22, 20, 37);
   --ag-popup-shadow: var(--ag-card-shadow);
   --ag-tab-min-width: 350px;

}

.ag-theme-alpine .ag-popup-child {
 background-color: rgba(47, 35, 93, 0.863); /* dark purple */
}


@media screen and (min-width: 300px) {
 .ag-theme-alpine {
   --ag-font-size: 12px;
 }
}


@media screen and (min-width: 600px) {
 .ag-theme-alpine {
   --ag-font-size: 15px;
 }
}

@media screen and (min-width: 900px) {
 .ag-theme-alpine {
   --ag-font-size: 18px;
 }
}

.form-select {
 max-width: 150px;
 display: inline;
 margin: auto;
 background-color: #a2a9bb;

}

.pag {
 text-align: right;
 padding: 5px;
}

.oldalak {
 font-size: x-large;
 padding-inline: 15px;
 color: #1b2952;
}
</style>
