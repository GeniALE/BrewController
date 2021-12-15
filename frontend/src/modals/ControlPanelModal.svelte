<script lang="ts">
  import { mutation } from '@urql/svelte'
  import { Button } from 'carbon-components-svelte'
  import GaugeValueForm from 'forms/GaugeValueForm.svelte'
  import { AddNewGaugeValueDocument } from 'generated/operations'
  import type { AddNewGaugeValueMutation, AddNewGaugeValueMutationVariables } from 'generated/queries'
  import { destroyModal, modal } from 'utils/modal'

  export let showModal: boolean
  export let controlId: string
  export let controlType: 'gauge' | 'toggler'

  let edited: boolean
  let value: number

  const addGaugeValue = mutation<AddNewGaugeValueMutation, AddNewGaugeValueMutationVariables>({ query: AddNewGaugeValueDocument })

  const submit = async () => {
    await addGaugeValue({
      gaugeId: controlId,
      value,
    })

    close()
  }

  const close = () => {
    $destroyModal?.()
  }
</script>

<div class="modal" role="dialog" use:modal={() => showModal = false}>
  <div class="info">
    {#if controlType === 'gauge'}
      <GaugeValueForm bind:edited={edited} bind:value={value} gaugeId={controlId} />
    {/if}
  </div>
  <div class="content">
    <div class="chart">
      chart
    </div>
    <div class="confirm-actions bx--btn-set">
      <Button kind="secondary" on:click={close}>Cancel</Button>
      <Button disabled={!edited} on:click={submit}>Submit</Button>
    </div>
  </div>
</div>

<style lang="scss">
  .modal {
    width: min(1200px, 90vw);
    height: min(800px, 80vh);
    background: var(--cds-ui-01);
    display: flex;
  }

  .info {
    width: 400px;
    padding: 16px;
    background: var(--cds-ui-03);
  }

  .content {
    flex-grow: 1;
    display: flex;
    flex-direction: column;
    position: relative;

    .chart {
      flex-grow: 1;
      padding: 16px;
    }

    .confirm-actions {
      display: flex;
      justify-content: flex-end;
    }
  }
</style>
