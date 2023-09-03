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
 import { AgGridVue } from "ag-grid-vue3";  // the AG Grid Vue Component
 import { reactive, onMounted, ref } from "vue";
 import "ag-grid-community/styles/ag-grid.css"; // Core grid CSS, always needed
 import "ag-grid-community/styles/ag-theme-alpine.css"; // Optional theme CSS
 import axios from 'axios';
 import "../assets/main.css";
 import * as a from 'moment';
 import { AG_GRID_LOCALE_HU } from "../js/locale.hu.js";
 //import { useDateFormat } from '@vueuse/core'
 import { CheckboxCellRenderer } from "../js/checkbox-cell-renderer.js";
 
 const collection = [];
 var totalItem = ref(null);
 
 const checked= ref(null);
 
 //variables for validation values
 const minRaktarNeve = 0;
 const minRaktarHelye = 3;
 const minBerlesiIdo = 0;
 
 
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
 
       if (event.column.colId == 'raktar_neve')  {
         if (event.newValue.length > minRaktarNeve) {
           console.log(event)
           collection.push(event);
         }
       }
 
       if (event.column.colId == 'raktar_helye')  {
         if (event.newValue.length > minRaktarHelye) {
           console.log(event)
           collection.push(event);
         }
       }
 
 
       if (event.column.colId == 'Berlesi_ido')  {
         if (event.newValue > minBerlesiIdo) {
           console.log(event)
           collection.push(event);
         }
       }
 
 
     },
   },
 
     created() {
       this.localeText = AG_GRID_LOCALE_HU;  
 
       this.frameworkComponents = {
         checkboxRenderer: CheckboxCellRenderer
       };
       
       this.paginationPageSize = 10;
 
   },
   setup() {
     const gridApi = ref(null); // Optional - for accessing Grid's API
     const rowData = reactive({}); // Set rowData to Array of Objects, one Object per Row
     // Obtain API from grid's onGridReady event
     const onGridReady = (params) => {
       gridApi.value = params.api;
     };
 
     // Example load data from server
     onMounted(() => {
       axios.get('http://localhost:5000/api/raktarok')
         .then(result => totalItem.value = result.data.totalItems);
       axios.get('http://localhost:5000/api/raktarok')
         .then(result => rowData.value = result.data.data);
 
     });
 
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
     
     const columnDefs = ref({
       value: [
         {
           headerName: 'Raktár neve', field: "raktar_neve", sortable: true,
           cellStyle : params => params.value.length <= minRaktarNeve ? {backgroundColor : 'red'} : {backgroundColor : 'transparent'},
           filterParams: {
             filterOptions: ['contains', 'startsWith', 'endsWith'],
             defaultOption: 'contains'
           }
         },
         {
           headerName: 'Raktár helye', field: "raktar_helye", sortable: true,
           cellStyle : params => params.value.length <= minRaktarHelye ? {backgroundColor : 'red'} : {backgroundColor : 'transparent'},
           filterParams: {
             filterOptions: ['contains', 'startsWith', 'endsWith'],
             defaultOption: 'contains'
           },
         },
         {
           headerName: "Bérlési idő", field: "Berlesi_ido", sortable: true, editable : false, 
             valueFormatter: function (params) {
             return a(params.value).format('YYYY.MM.DD')
           },
           filterParams: {
             filterOptions: ['contains', 'startsWith', 'endsWith'],
             defaultOption: 'contains',
           }
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
         
         collection.forEach(element => {
           if (element.oldValue != element.newValue) {
           newvv +=  element.data.raktar_neve + " : " +
             element.oldValue + " => " + element.newValue + "\n"
           }
         })
       
         if(collection.length>0) {
           if (confirm('Módosítások mentése?\n' + newvv) === true) {
             collection.forEach(PutToDatabase => {
               axios({
                 method: 'put',
                 url: 'api/raktarok/' + PutToDatabase.data.raktarID,
                 data: {
                   raktarID: PutToDatabase.data.raktarID,
                   raktar_neve: PutToDatabase.data.raktar_neve,
                   raktar_helye: PutToDatabase.data.raktar_helye,
                   
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
         //console.log(Number(value));
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