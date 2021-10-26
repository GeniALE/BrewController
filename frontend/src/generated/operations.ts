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
    rank
  }
}
    `;
export const AddNewCategoryDocument = gql`
    mutation AddNewCategory($newCategory: AddCategoryInput!, $previousCategoryId: String, $nextCategoryId: String) {
  addCategory(
    newCategory: $newCategory
    previousCategoryId: $previousCategoryId
    nextCategoryId: $nextCategoryId
  ) {
    id
  }
}
    `;
export const UpdateCategoryDocument = gql`
    mutation UpdateCategory($updatedCategory: UpdateCategoryInput!, $previousCategoryId: String, $nextCategoryId: String) {
  updateCategory(
    updatedCategory: $updatedCategory
    previousCategoryId: $previousCategoryId
    nextCategoryId: $nextCategoryId
  ) {
    id
  }
}
    `;
export const GetLatestGaugeValueDocument = gql`
    subscription GetLatestGaugeValue($gaugeId: String!) {
  latestGaugeValue(gaugeId: $gaugeId) {
    id
    value
    gaugeId
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