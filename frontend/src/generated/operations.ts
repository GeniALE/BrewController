// file generated! DO NOT TOUCH!
/* eslint-disable */
import gql from 'graphql-tag';
export type Omit<T, K extends keyof T> = Pick<T, Exclude<keyof T, K>>;

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
    id
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
    id
    message
    type
    date
    time
  }
}
    `;