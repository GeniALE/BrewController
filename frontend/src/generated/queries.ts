// file generated! DO NOT TOUCH!
/* eslint-disable */
// @ts-nocheck
import * as Types from './schema';

export type GetLatestGaugeValueSubscriptionVariables = Types.Exact<{
  gaugeId: Types.Scalars['String'];
}>;


export type GetLatestGaugeValueSubscription = { readonly __typename?: 'Subscription', readonly latestGaugeValue: { readonly __typename?: 'GaugeValue', readonly id: string, readonly value: number, readonly gaugeId: string } };

export type GetLogsQueryVariables = Types.Exact<{ [key: string]: never; }>;


export type GetLogsQuery = { readonly __typename?: 'Query', readonly logs: ReadonlyArray<{ readonly __typename?: 'Log', readonly type: Types.LogType, readonly message: string, readonly date: string, readonly time: string }> };

export type GetLatestLogSubscriptionVariables = Types.Exact<{ [key: string]: never; }>;


export type GetLatestLogSubscription = { readonly __typename?: 'Subscription', readonly latestLog: { readonly __typename?: 'Log', readonly type: Types.LogType, readonly message: string, readonly date: string, readonly time: string } };
