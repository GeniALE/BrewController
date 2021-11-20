<script lang="ts">
  import LogLine from 'components/LogLine.svelte'
  import { operationStore, query, subscription, SubscriptionHandler } from '@urql/svelte'
  import { GetLatestLogDocument, GetLogsDocument } from 'generated/operations'
  import type { GetLatestLogSubscription, GetLatestLogSubscriptionVariables, GetLogsQuery, GetLogsQueryVariables } from 'generated/queries'
  import Title from 'components/Title.svelte'

  const logs = operationStore<GetLogsQuery, GetLogsQueryVariables>(GetLogsDocument)
  const latestLogs = operationStore<GetLatestLogSubscription, GetLatestLogSubscriptionVariables, GetLogsQuery['logs']>(GetLatestLogDocument)

  const handleSubscription: SubscriptionHandler<GetLatestLogSubscription, GetLogsQuery['logs']> = (latestLogs = [], data) => {
    return [data.latestLog, ...latestLogs]
  }

  query(logs)
  subscription(latestLogs, handleSubscription)
</script>

<Title>Logs</Title>

{#if $logs.fetching}
  loading...
{:else if $logs.error}
  <span>{$logs.error.message}</span>
{:else}
  {#each [...($latestLogs.data ?? []), ...$logs.data.logs] as log}
    <LogLine {log} />
  {/each}
{/if}
