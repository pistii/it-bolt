
export const CheckboxCellRenderer  = {
    
  template: `
    <input 
      type="checkbox" 
      @click="checkedHandler($event)"
      :checked="params.value"
    />
    `,
  methods: {
    checkedHandler(event) {
      let checked = event.target.checked;
      let colId = this.params.column.colId;
      this.params.node.setDataValue(colId, checked);
    }
  }
};
