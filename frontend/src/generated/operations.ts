// file generated! DO NOT TOUCH!
/* eslint-disable */
import gql from 'graphql-tag';
export type Omit<T, K extends keyof T> = Pick<T, Exclude<keyof T, K>>;

export const GetCategoriesDocument = gql`
    query GetCategories {
  categories {
    id
    name
    color
    rank
  }
}
    `;
export const GetCategoryByIdDocument = gql`
    query GetCategoryById($id: String!) {
  category(categoryId: $id) {
    name
    color
  }
}
    `;
export const AddNewCategoryDocument = gql`
    mutation AddNewCategory($newCategory: AddCategoryInput!, $ranking: RankingInput!) {
  addCategory(newCategory: $newCategory, ranking: $ranking) {
    id
  }
}
    `;
export const UpdateCategoryDocument = gql`
    mutation UpdateCategory($updatedCategory: UpdateCategoryInput!, $ranking: RankingInput) {
  updateCategory(updatedCategory: $updatedCategory, ranking: $ranking) {
    id
  }
}
    `;
export const GetLatestGaugeValueDocument = gql`
    subscription GetLatestGaugeValue($gaugeId: String!) {
  latestGaugeValue(gaugeId: $gaugeId) {
    id
    value
  }
}
    `;
export const GetCurrentLatestGaugeValueDocument = gql`
    query GetCurrentLatestGaugeValue($gaugeId: String!) {
  latestGaugeValue(gaugeId: $gaugeId) {
    id
    value
  }
}
    `;
export const GetGaugesDocument = gql`
    query GetGauges {
  gauges {
    id
    nodeId
    nodeName
    name
    description
    type
    rank
    interactive
    categoryId
  }
}
    `;
export const GetGaugeByIdDocument = gql`
    query GetGaugeById($id: String!) {
  gauge(gaugeId: $id) {
    id
    nodeId
    nodeName
    name
    description
    type
    rank
    interactive
    categoryId
  }
}
    `;
export const GetCurrentGaugesDocument = gql`
    query GetCurrentGauges {
  gauges {
    id
    nodeId
    nodeName
    name
    latestValue {
      value
    }
  }
}
    `;
export const AddNewGaugeDocument = gql`
    mutation AddNewGauge($newGauge: AddGaugeInput!, $ranking: RankingInput!) {
  addGauge(newGauge: $newGauge, ranking: $ranking) {
    id
  }
}
    `;
export const UpdateGaugeDocument = gql`
    mutation UpdateGauge($updatedGauge: UpdateGaugeInput!, $ranking: RankingInput) {
  updateGauge(updatedGauge: $updatedGauge, ranking: $ranking) {
    id
  }
}
    `;
export const GetLogsDocument = gql`
    query GetLogs {
  logs {
    type
    message
    date
    time
  }
}
    `;
export const GetLatestLogDocument = gql`
    subscription GetLatestLog {
  latestLog {
    type
    message
    date
    time
  }
}
    `;