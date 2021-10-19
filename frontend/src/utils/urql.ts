import { createClient, defaultExchanges, subscriptionExchange } from '@urql/svelte'

import { SubscriptionClient } from 'subscriptions-transport-ws'

const wsClient = new SubscriptionClient('ws://localhost:5000/graphql', {
  reconnect: true,
})

const client = createClient({
  url: 'http://localhost:5000/graphql',
  exchanges: [
    ...defaultExchanges,
    subscriptionExchange({
      // @ts-expect-error: Copied from docs, don't know why there is an error here
      forwardSubscription: (operation) => wsClient.request(operation),
    }),
  ],
})

export default client
