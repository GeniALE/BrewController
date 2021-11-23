<script lang="ts">
  import { operationStore, subscription } from '@urql/svelte'
  import { AspectRatio, ClickableTile } from 'carbon-components-svelte'
  import { GetLatestGaugeValueDocument } from 'generated/operations'
  import type { GetCurrentGaugesQuery, GetLatestGaugeValueSubscription, GetLatestGaugeValueSubscriptionVariables } from 'generated/queries'
  import ControlPanelModal from 'modals/ControlPanelModal.svelte'
  import { modal } from 'utils/modal'

  export let gauge: GetCurrentGaugesQuery['gauges'][number]

  let showModal = false

  const latestValue = operationStore<GetLatestGaugeValueSubscription, GetLatestGaugeValueSubscriptionVariables>(GetLatestGaugeValueDocument, {
    gaugeId: gauge.id,
  })

  subscription(latestValue)
</script>

<AspectRatio>
  <ClickableTile style="height: 100%" on:click={() => showModal = true}>
    <div class="tile-content">
      <span class="gauge-name">{gauge.name ?? gauge.nodeName}</span>
      <span class="gauge-value">{$latestValue.data?.latestGaugeValue.value ?? gauge.latestValue?.value ?? 'N/A'}</span>
    </div>
  </ClickableTile>
</AspectRatio>

{#if showModal}
  <div use:modal={() => showModal = false}>
    <ControlPanelModal controlId={gauge.id} controlType="gauge" />
  </div>
{/if}

<style lang="scss">
  .tile-content {
    display: flex;
    flex-direction: column;
    row-gap: 16px;

    .gauge-name {
      font-weight: bold;
      font-size: 1.5rem;
    }

    .gauge-value {
      font-size: 1.25rem;
    }
  }
</style>
