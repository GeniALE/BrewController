<script lang="ts">
  import { Button, ClickableTile, NumberInput, NumberInputSkeleton, SkeletonPlaceholder, SkeletonText } from 'carbon-components-svelte'
  import { operationStore, query } from '@urql/svelte'
  import { GetCurrentLatestGaugeValueDocument, GetGaugeByIdDocument } from 'generated/operations'
  import type { GetCurrentLatestGaugeValueQuery, GetCurrentLatestGaugeValueQueryVariables, GetGaugeByIdQuery, GetGaugeByIdQueryVariables } from 'generated/queries'


  export let edited: boolean
  export let value: number
  export let gaugeId: string

  const gauge = operationStore<GetGaugeByIdQuery, GetGaugeByIdQueryVariables>(GetGaugeByIdDocument, {
    id: gaugeId,
  })

  const gaugeValue = operationStore<GetCurrentLatestGaugeValueQuery, GetCurrentLatestGaugeValueQueryVariables>(GetCurrentLatestGaugeValueDocument, {
    gaugeId,
  })

  query(gauge)
  query(gaugeValue)
</script>

<div class="form">
  {#if $gauge.fetching || !$gauge.data}
    <SkeletonText heading />
    <SkeletonText paragraph />
  {:else if $gauge.error}
    <p>{$gauge.error.message}</p>
  {:else}
    <h2>{$gauge.data.gauge.name} ({$gauge.data.gauge.nodeName})</h2>
    <p>{$gauge.data.gauge.description}</p>
    {#if $gaugeValue.fetching || !$gaugeValue.data}
      <NumberInputSkeleton />
    {:else if $gaugeValue.error}
      <p>{$gaugeValue.error.message}</p>
    {:else}
      <NumberInput hideSteppers label="Value" size="xl" value={$gaugeValue.data.latestGaugeValue.value} />
    {/if}
    {#if $gauge.data.gauge.interactive}
      <div class="buttons">
        {#if $gaugeValue.fetching || !$gaugeValue.data}
          <SkeletonPlaceholder />
          <SkeletonPlaceholder />
          <SkeletonPlaceholder />
          <SkeletonPlaceholder />
        {:else}
          <ClickableTile>-10</ClickableTile>
          <ClickableTile>-1</ClickableTile>
          <ClickableTile>+1</ClickableTile>
          <ClickableTile>+10</ClickableTile>
        {/if}
      </div>
    {/if}
  {/if}
</div>

<style lang="scss">
  .form {
    display: flex;
    flex-direction: column;
    row-gap: 16px;
  }

  .buttons {
    display: flex;
    flex-direction: column;
    row-gap: 8px;
  }
</style>
