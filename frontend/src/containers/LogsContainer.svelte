<script lang="ts">
  import Box from 'components/Box.svelte'
  import LogLine from 'components/LogLine.svelte'
  import ScrollContainer from 'components/ScrollContainer.svelte'
  import { operationStore, query, subscription, SubscriptionHandler } from '@urql/svelte'
  import { GetLatestLogDocument, GetLogsDocument } from 'generated/operations'
  import type { GetLatestGaugeValueSubscriptionVariables, GetLatestLogSubscription, GetLogsQuery, GetLogsQueryVariables } from 'generated/queries'

  const logs = operationStore<GetLogsQuery, GetLogsQueryVariables>(GetLogsDocument)
  const latestLogs = operationStore<GetLatestLogSubscription, GetLatestGaugeValueSubscriptionVariables, GetLogsQuery['logs']>(GetLatestLogDocument)

  const handleSubscription: SubscriptionHandler<GetLatestLogSubscription, GetLogsQuery['logs']> = (latestLogs = [], data) => {
    return [data.latestLog, ...latestLogs]
  }

  query(logs)
  subscription(latestLogs, handleSubscription)
</script>

<Box title="Logs" area="logs">
  <ScrollContainer>
    {#if $logs.fetching}
      loading...
    {:else if $logs.error}
      <span>{$logs.error.message}</span>
    {:else}
      {#each [...($latestLogs.data ?? []), ...$logs.data.logs] as log}
        <LogLine {log} />
      {/each}
    {/if}
  </ScrollContainer>
</Box>
