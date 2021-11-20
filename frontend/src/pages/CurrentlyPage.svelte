<script lang="ts">
  import { operationStore, query } from '@urql/svelte'
  import CurrentGauge from 'components/CurrentGauge.svelte'
  import { GetCurrentGaugesDocument } from 'generated/operations'
  import type { GetCurrentGaugesQuery, GetCurrentGaugesQueryVariables } from 'generated/queries'

  const gauges = operationStore<GetCurrentGaugesQuery, GetCurrentGaugesQueryVariables>(GetCurrentGaugesDocument)

  query(gauges)
</script>

{#if $gauges.fetching}
  <span>loading...</span>
{:else if $gauges.error}
  <span>{$gauges.error.message}</span>
{:else}
  <div class="gauges-list">
    {#each $gauges.data.gauges as gauge}
      <CurrentGauge {gauge} />
    {/each}
  </div>
{/if}

<style lang="scss">
  .gauges-list {
    display: grid;
    grid-template-columns: repeat(auto-fill, minmax(300px, 1fr));
    gap: 16px;
  }
</style>
