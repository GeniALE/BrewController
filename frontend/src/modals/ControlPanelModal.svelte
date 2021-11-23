<script lang="ts">
  export let controlId: string
  export let controlType: 'gauge' | 'toggler'
</script>

<div class="modal" role="dialog">
  {`${controlId}-${controlType}`}
</div>

<style lang="scss">
  .modal {
    background: var(--cds-ui-01);
  }
</style>
