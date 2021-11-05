<script lang="ts">
  import Title from 'components/Title.svelte'
  import { GetGaugesDocument } from 'generated/operations';
  import { Button, ClickableTile } from 'carbon-components-svelte'
  import type { GetGaugesQuery, GetGaugesQueryVariables } from 'generated/queries';
  import { operationStore, query } from '@urql/svelte'
  import { useNavigate } from 'svelte-navigator'

  const navigate = useNavigate()

  const gauges = operationStore<GetGaugesQuery, GetGaugesQueryVariables>(GetGaugesDocument)

  query(gauges)
</script>

<Title>Gauges</Title>

<Button on:click={() => navigate('edit')}>Add Gauge</Button>
{#if $gauges.fetching}
  <span>loading...</span>
{:else if $gauges.error}
  <span>{$gauges.error.message}</span>
{:else}
<div class="categories-list">
  {#each $gauges.data.gauges as gauge}
    <ClickableTile on:click={() => navigate(`edit?id=${gauge.id}`)}>{gauge.name}</ClickableTile>
  {/each}
</div>
{/if}