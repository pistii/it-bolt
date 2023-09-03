<template>
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
        <ag-grid-vue class="ag-theme-alpine table-responsive table" 
        style="height: 678px; 
        text-align: left;" 
        :columnDefs="columnDefs.value"
          :rowData="rowData.value" 
          :defaultColDef="defaultColDef" 
          animateRows="true" @grid-ready="onGridReady" 
                :tooltipShowDelay="tooltipShowDelay"
                :tooltipHideDelay="tooltipHideDelay"
                :pagination="true" 
                :paginationPageSize="paginationPageSize"
                :localeText="localeText"
          @cell-editing-started="onCellEditingStarted" 
          @cell-editing-stopped="onCellEditingStopped"          
          :rowSelection="rowSelection"
          @selection-changed="onSelectionChanged"
          @pagination-changed="onPaginationChanged"
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
import { CheckboxCellRenderer } from "../js/checkbox-cell-renderer.js";


const collection = [];
var totalItem = ref(null);

const checked = ref(null);

//variables for validation values
const minEszkozNeve = 3;
const minEszkozAr = 500;
const minSorozatSzam = 3;

//Starting value if user updating cell
var startValue = 0;
// const EszkozAr = {
//   setup(props) {
//     const {params} = props
//     console.log(params)
//     return () => h("span", params.value)
//   }
// }
//var startedEditing = ref(null);




export default {
  name: "App",
  components: {
    AgGridVue, 
    'ag-grid-vue': AgGridVue,
    
  },
  methods: {

    onCellEditingStarted(event) {
      //startedEditing = event.value;
      startValue = event.value
      console.log('cellEditingStarted ' + event);
    },
    onCellEditingStopped(event) { //validálás

      if (event.column.colId == 'eszkoz_neve')  {
        if (event.newValue.length > minEszkozNeve) {
          console.log(event)
          collection.push(event);
        }
      }

      if (event.column.colId == 'eszkoz_ara')  {
        if ((event.newValue > minEszkozAr && Number.isInteger(parseInt(event.newValue))) ) {
          collection.push(event);
        }
      }

      if (event.column.colId == 'eszkoz_sorozatszama')  {
        if (event.newValue.length > minSorozatSzam) {
          collection.push(event);
        }
      }

      if (event.column.colId == 'garancialis_e')  {
        if ((event.newValue == 1 || event.newValue == 0)) {
          collection.push(event);
        }
      }

      if (event.column.colId == 'kedvezmenyes_e')  {
        if ((event.newValue == 1 || event.newValue == 0)) {
          collection.push(event);
        }
      }

      if (event.column.colId == 'raktar_keszlet')  {
        if (Number.isInteger(parseInt(event.value))) {
          collection.push(event);
        }
      }

    },

    onBtStopEditing() {
      this.gridApi.stopEditing();
    },

    
 checkedHandler(params) {
      console.log(params);
      if (this.checkboxSelection) {
        checked.value.push("ssh");
      }
    }

   
  },


  created() {
    
    this.localeText = AG_GRID_LOCALE_HU;
    this.frameworkComponents = {
      checkboxRenderer: CheckboxCellRenderer
    };
    
    this.tooltipShowDelay = 0;
    this.tooltipHideDelay = 2000;
    
    this.paginationPageSize = 10;

  },
  setup() {
    const gridApi = ref(null); // Optional - for accessing Grid's API
    // Obtain API from grid's onGridReady event


    const onGridReady = (params) => {
      gridApi.value = params.api;
    };

    
    const columnDefs = reactive({
      value: [
        {
          headerName: 'Eszköz neve', tooltipField : "eszkoz_neve", 
          field: "eszkoz_neve", 
          wrapText: true,
          autoHeight: true,
          cellStyle : params => params.value.length <= minEszkozNeve ? {backgroundColor : 'red'} : {backgroundColor : 'transparent'},
          // cellStyle: function(params) {
          //   console.log(params.value)
          //   if (params.value==null){ 
          //       return {backgroundColor: '#ff0000'};
          //       //console.log(params.newValue);

          //       }
          //   else { 
          //   return {color: 'red', backgroundColor: 'black'};
          //   }
          //   },
          minWidth: 80,
          sortable: true,
          filterParams: {
            filterOptions: ['contains', 'startsWith', 'endsWith'],
            defaultOption: 'contains'
          }
        },
        {
          headerName: 'eszköz ára', tooltipField : 'eszkoz_ara', 
          cellStyle : params => params.value <= minEszkozAr | !Number.isInteger(parseInt(params.value)) ? {backgroundColor : 'red'} : {backgroundColor : 'transparent'},
          cellRenderer : params => Number.isInteger(parseInt(params.value)) ? params.value : startValue,
          field: "eszkoz_ara",
          sortable: true,
          minWidth: 40,
          hide: (window.innerWidth < 760 ? true : false),
          filterParams: {
            filterOptions: ['contains', 'startsWith', 'endsWith'],
            defaultOption: 'contains'
          },
        },
        {
          headerName: "Gyártási idő",
          field: "eszkoz_gyartas_ev",
          sortable: true,
          editable: false,
          wrapText: true,
          autoHeight: true,
          minWidth: 80,
          valueFormatter: function (params) {
            return a(params.value).format('YYYY.MM.DD.')
          },
          filterParams: {
            filterOptions: ['contains', 'startsWith', 'endsWith'],
            defaultOption: 'contains'
          }
        },
        {
          headerName: "Sorozatszám",  tooltipField : 'eszkoz_sorozatszama', 
          field: "eszkoz_sorozatszama",
          cellStyle : params => params.value.length <= minSorozatSzam ? {backgroundColor : 'red'} : {backgroundColor : 'transparent'},
          sortable: true,
          minWidth: 40,
          filterParams: {
            filterOptions: ['contains', 'startsWith', 'endsWith'],
            defaultOption: 'contains'
          }
        },
        {
          headerName: "Garancia",
          field: "garancialis_e",
          editable: true,
          minWidth: 15,
          filterParams: {
            filterOptions: ['contains', 'notContains']
          },
          hide: window.innerWidth < 760 ? true : false,
         valueFormatter: params =>  params.value === 1 ? 'Garanciális' : "Nem Garanciális",
         //cellRenderer : params => {
          //       return `<input type='checkbox' @click="checkedHandler(params)"
          //  ${params.value ? 'checked' : ''} />`; }
          

        },
        {
          headerName: "Kedvezményes",
          field: "kedvezmenyes_e",
          minWidth: 15,
          filterParams: {
            filterOptions: ['contains', 'notContains']
          },
          hide: (window.innerWidth < 760 ? true : false),
          valueFormatter: params =>  params.value === 1 ? 'Kedvezményes' : "Nem Kedvezményes",
        },
        {
          headerName: "Raktárkészlet", field: "raktar_keszlet", sortable: true,
          minWidth: 25,  tooltipField : 'raktar_keszlet', 
          cellStyle : params => !Number.isInteger(parseInt(params.value)) ? {backgroundColor : 'red'} : {backgroundColor : 'transparent'},
          filterParams: {
            filterOptions: ['contains', 'startsWith', 'endsWith'],
            defaultOption: 'contains'
          }
        },
        //  { headerName: "eszkoz tipus", field: "eszkoz_tipus",  sortable: true,}
      ],
    })

    const defaultColDef = {
      sortable: true,
      editable: true,
      flex: 1,
      filter: true,
      resizable: true,
      wrapHeaderText: true,
      autoHeaderHeight: true,
      
    };

    // Load data from server
    onMounted(() => {
      axios.get('http://localhost:5000/api/eszkozok')
        .then(result => totalItem.value = result.data.totalItems);
      axios.get('http://localhost:5000/api/eszkozok')
        .then(result => rowData.value = result.data.data);

    });

    const rowData = reactive({}); // Set rowData to Array of Objects, one Object per Row



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
              newvv += element.data.eszkoz_neve + " : " +
                element.oldValue + " => " + element.newValue + "\n"
            }
          })
        
        if(collection.length>0) {
          if (confirm('Módosítások mentése?\n' + newvv) === true) {
            collection.forEach(update => {
              axios({
                method: 'put',
                url: 'api/eszkozok/' + update.data.eszkozID,
                data: {
                  eszkozID: update.data.eszkozID,
                  gyartoID: update.data.gyartoID,
                  eszkoz_neve: update.data.eszkoz_neve,
                  eszkoz_ara: update.data.eszkoz_ara,
                  eszkoz_sorozatszama: update.data.eszkoz_sorozatszama,
                  eszkoz_gyartas_ev: update.data.eszkoz_gyartas_ev,
                  kategoriaID: update.data.kategoriaID,
                  raktar_keszlet: update.data.raktar_keszlet,
                  garancialis_e: update.data.garancialis_e,
                  kedvezmenyes_e: update.data.kedvezmenyes_e,
                  eszkoz_tipus: update.data.eszkoz_tipus,
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
      },


      // onSelectionChanged() {
      //   var selectedRows = gridApi.value.getSelectedRows();
        
      //   console.log(selectedRows);
      // },

      
    

    };
  }
};




// const dateFormat = function dateFormat(params) { //Reformat the parameters
//   return Date.format('YYYY MM dd')
// };

// const formatted = function formatted(params) {
//   const datum = params.value;
//   return useDateFormat(datum, 'YYYY');
// };

// const GuaranteeFormat = function GuaranteeFormat(params) { //Reformat the parameters
//   if (params.value == 1) {
//     return "Garanciális"
//   } else {
//     return "Nem garanciális"
//   }
// };

// const DiscountFormat = function DiscountFormat(params) {
//   if (params.value == 1) {
//     return "Kedvezményes"
//   } else {
//     return "Nem kedvezményes"
//   }
// };

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