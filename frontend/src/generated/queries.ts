// file generated! DO NOT TOUCH!
/* eslint-disable */
// @ts-nocheck
import * as Types from './schema';

export type GetCategoriesQueryVariables = Types.Exact<{ [key: string]: never; }>;


export type GetCategoriesQuery = { readonly __typename?: 'Query', readonly categories: ReadonlyArray<{ readonly __typename?: 'Category', readonly id: string, readonly name: string, readonly color: string, readonly rank: string }> };

export type GetCategoryByIdQueryVariables = Types.Exact<{
  id: Types.Scalars['String'];
}>;


export type GetCategoryByIdQuery = { readonly __typename?: 'Query', readonly category: { readonly __typename?: 'Category', readonly name: string, readonly color: string } };

export type AddNewCategoryMutationVariables = Types.Exact<{
  newCategory: Types.AddCategoryInput;
  ranking: Types.RankingInput;
}>;


export type AddNewCategoryMutation = { readonly __typename?: 'Mutation', readonly addCategory: { readonly __typename?: 'Category', readonly id: string } };

export type UpdateCategoryMutationVariables = Types.Exact<{
  updatedCategory: Types.UpdateCategoryInput;
  ranking?: Types.InputMaybe<Types.RankingInput>;
}>;


export type UpdateCategoryMutation = { readonly __typename?: 'Mutation', readonly updateCategory: { readonly __typename?: 'Category', readonly id: string } };

export type GetLatestGaugeValueSubscriptionVariables = Types.Exact<{
  gaugeId: Types.Scalars['String'];
}>;


export type GetLatestGaugeValueSubscription = { readonly __typename?: 'Subscription', readonly latestGaugeValue: { readonly __typename?: 'GaugeValue', readonly id: string, readonly value: number } };

export type GetCurrentLatestGaugeValueQueryVariables = Types.Exact<{
  gaugeId: Types.Scalars['String'];
}>;


export type GetCurrentLatestGaugeValueQuery = { readonly __typename?: 'Query', readonly latestGaugeValue?: { readonly __typename?: 'GaugeValue', readonly id: string, readonly value: number } | null | undefined };

export type AddNewGaugeValueMutationVariables = Types.Exact<{
  gaugeId: Types.Scalars['String'];
  value: Types.Scalars['Float'];
}>;


export type AddNewGaugeValueMutation = { readonly __typename?: 'Mutation', readonly addGaugeValue: { readonly __typename?: 'GaugeValue', readonly gaugeId: string, readonly value: number } };

export type GetGaugesQueryVariables = Types.Exact<{ [key: string]: never; }>;


export type GetGaugesQuery = { readonly __typename?: 'Query', readonly gauges: ReadonlyArray<{ readonly __typename?: 'Gauge', readonly id: string, readonly nodeId: string, readonly nodeName: string, readonly name?: string | null | undefined, readonly description?: string | null | undefined, readonly type: Types.GaugeType, readonly rank: string, readonly interactive: boolean, readonly categoryId?: string | null | undefined }> };

export type GetGaugeByIdQueryVariables = Types.Exact<{
  id: Types.Scalars['String'];
}>;


export type GetGaugeByIdQuery = { readonly __typename?: 'Query', readonly gauge: { readonly __typename?: 'Gauge', readonly id: string, readonly nodeId: string, readonly nodeName: string, readonly name?: string | null | undefined, readonly description?: string | null | undefined, readonly type: Types.GaugeType, readonly rank: string, readonly interactive: boolean, readonly categoryId?: string | null | undefined } };

export type GetCurrentGaugesQueryVariables = Types.Exact<{ [key: string]: never; }>;


export type GetCurrentGaugesQuery = { readonly __typename?: 'Query', readonly gauges: ReadonlyArray<{ readonly __typename?: 'Gauge', readonly id: string, readonly nodeId: string, readonly nodeName: string, readonly name?: string | null | undefined, readonly latestValue?: { readonly __typename?: 'GaugeValue', readonly value: number } | null | undefined }> };

export type AddNewGaugeMutationVariables = Types.Exact<{
  newGauge: Types.AddGaugeInput;
  ranking: Types.RankingInput;
}>;


export type AddNewGaugeMutation = { readonly __typename?: 'Mutation', readonly addGauge: { readonly __typename?: 'Gauge', readonly id: string } };

export type UpdateGaugeMutationVariables = Types.Exact<{
  updatedGauge: Types.UpdateGaugeInput;
  ranking?: Types.InputMaybe<Types.RankingInput>;
}>;


export type UpdateGaugeMutation = { readonly __typename?: 'Mutation', readonly updateGauge: { readonly __typename?: 'Gauge', readonly id: string } };

export type GetLogsQueryVariables = Types.Exact<{ [key: string]: never; }>;


export type GetLogsQuery = { readonly __typename?: 'Query', readonly logs: ReadonlyArray<{ readonly __typename?: 'Log', readonly type: Types.LogType, readonly message: string, readonly date: string, readonly time: string }> };

export type GetLatestLogSubscriptionVariables = Types.Exact<{ [key: string]: never; }>;


export type GetLatestLogSubscription = { readonly __typename?: 'Subscription', readonly latestLog: { readonly __typename?: 'Log', readonly type: Types.LogType, readonly message: string, readonly date: string, readonly time: string } };
