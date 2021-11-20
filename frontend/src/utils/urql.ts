import { createClient, defaultExchanges, subscriptionExchange } from '@urql/svelte'

import { SubscriptionClient } from 'subscriptions-transport-ws'
import { devtoolsExchange } from '@urql/devtools'

const wsClient = new SubscriptionClient('ws://localhost:5000/graphql', {
  reconnect: true,
})

let exchanges = [
  subscriptionExchange({
    forwardSubscription: (operation) => wsClient.request(operation),
  }),
  ...defaultExchanges,
]

if (process.env.NODE_ENV === 'development') {
  console.log('dev mode active')
  exchanges = [
    devtoolsExchange,
    ...exchanges,
  ]
}

const client = createClient({
  url: 'http://localhost:5000/graphql',
  exchanges,
})

export default client
