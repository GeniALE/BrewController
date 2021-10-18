// file generated! DO NOT TOUCH!
/* eslint-disable */
export type Maybe<T> = T;
export type Exact<T extends { [key: string]: unknown }> = { [K in keyof T]: T[K] };
export type MakeOptional<T, K extends keyof T> = Omit<T, K> & { [SubKey in K]?: Maybe<T[SubKey]> };
export type MakeMaybe<T, K extends keyof T> = Omit<T, K> & { [SubKey in K]: Maybe<T[SubKey]> };
/** All built-in and custom scalars, mapped to their actual values */
export type Scalars = {
  ID: string;
  String: string;
  Boolean: boolean;
  Int: number;
  Float: number;
  /** The `DateTime` scalar represents an ISO-8601 compliant date time type. */
  DateTime: any;
};

export type AddCategoryInput = {
  readonly color: Scalars['String'];
  readonly name: Scalars['String'];
  readonly rank: Scalars['Int'];
};

export type AddGaugeInput = {
  readonly description: Scalars['String'];
  readonly interactive: Scalars['Boolean'];
  readonly name: Scalars['String'];
  readonly physicalId: Scalars['String'];
  readonly rank: Scalars['Int'];
  readonly subcategoryId: Scalars['String'];
  readonly type: GaugeType;
};

export type AddSubcategoryInput = {
  readonly categoryId: Scalars['String'];
  readonly name: Scalars['String'];
  readonly rank: Scalars['Int'];
};

export type AddTogglerInput = {
  readonly description: Scalars['String'];
  readonly interactive: Scalars['Boolean'];
  readonly name: Scalars['String'];
  readonly physicalId: Scalars['String'];
  readonly rank: Scalars['Int'];
  readonly subcategoryId: Scalars['String'];
};

export type Category = {
  readonly __typename?: 'Category';
  readonly color: Scalars['String'];
  readonly id: Scalars['String'];
  readonly name: Scalars['String'];
  readonly rank: Scalars['Int'];
  readonly subcategories: ReadonlyArray<Subcategory>;
};

export type Gauge = {
  readonly __typename?: 'Gauge';
  readonly description: Scalars['String'];
  readonly id: Scalars['String'];
  readonly interactive: Scalars['Boolean'];
  readonly name: Scalars['String'];
  readonly physicalId: Scalars['String'];
  readonly rank: Scalars['Int'];
  readonly subcategory: Subcategory;
  readonly subcategoryId: Scalars['String'];
  readonly type: GaugeType;
  readonly values: ReadonlyArray<GaugeValue>;
};

export enum GaugeType {
  Pressure = 'PRESSURE',
  Temperature = 'TEMPERATURE'
}

export type GaugeValue = {
  readonly __typename?: 'GaugeValue';
  readonly createdAt: Scalars['DateTime'];
  readonly gaugeId: Scalars['String'];
  readonly id: Scalars['String'];
  readonly value: Scalars['Float'];
};

export type Log = {
  readonly __typename?: 'Log';
  readonly createdAt: Scalars['DateTime'];
  readonly date: Scalars['String'];
  readonly id: Scalars['String'];
  readonly message: Scalars['String'];
  readonly time: Scalars['String'];
  readonly type: LogType;
};

export enum LogType {
  Error = 'ERROR',
  Info = 'INFO',
  Update = 'UPDATE'
}

export type Mutation = {
  readonly __typename?: 'Mutation';
  readonly addCategory: Category;
  readonly addGauge: Gauge;
  readonly addGaugeValue: GaugeValue;
  readonly addLog: Log;
  readonly addSubcategory: Subcategory;
  readonly addToggler: Toggler;
  readonly addTogglerValue: TogglerValue;
  readonly deleteCategory: OperationResult;
  readonly deleteGauge: OperationResult;
  readonly deleteSubcategory: OperationResult;
  readonly deleteToggler: OperationResult;
  readonly updateCategory: Category;
  readonly updateGauge: Gauge;
  readonly updateSubcategory: Subcategory;
  readonly updateToggler: Toggler;
};


export type MutationAddCategoryArgs = {
  newCategory: AddCategoryInput;
};


export type MutationAddGaugeArgs = {
  newGauge: AddGaugeInput;
};


export type MutationAddGaugeValueArgs = {
  gaugeId: Scalars['String'];
  value: Scalars['Float'];
};


export type MutationAddLogArgs = {
  message: Scalars['String'];
  type: LogType;
};


export type MutationAddSubcategoryArgs = {
  newSubcategory: AddSubcategoryInput;
};


export type MutationAddTogglerArgs = {
  newToggler: AddTogglerInput;
};


export type MutationAddTogglerValueArgs = {
  status: TogglerStatus;
  togglerId: Scalars['String'];
};


export type MutationDeleteCategoryArgs = {
  categoryId: Scalars['String'];
};


export type MutationDeleteGaugeArgs = {
  gaugeId: Scalars['String'];
};


export type MutationDeleteSubcategoryArgs = {
  subcategoryId: Scalars['String'];
};


export type MutationDeleteTogglerArgs = {
  togglerId: Scalars['String'];
};


export type MutationUpdateCategoryArgs = {
  updatedCategory: UpdateCategoryInput;
};


export type MutationUpdateGaugeArgs = {
  updatedGauge: UpdateGaugeInput;
};


export type MutationUpdateSubcategoryArgs = {
  updatedSubcategory: UpdateSubcategoryInput;
};


export type MutationUpdateTogglerArgs = {
  updatedToggler: UpdateTogglerInput;
};

export type OperationResult = {
  readonly __typename?: 'OperationResult';
  readonly worked: Scalars['Boolean'];
};

export type Query = {
  readonly __typename?: 'Query';
  readonly categories: ReadonlyArray<Category>;
  readonly category: Category;
  readonly gauge: Gauge;
  readonly gauges: ReadonlyArray<Gauge>;
  readonly logs: ReadonlyArray<Log>;
  readonly subcategories: ReadonlyArray<Subcategory>;
  readonly subcategory: Subcategory;
  readonly toggler: Toggler;
  readonly togglers: ReadonlyArray<Toggler>;
};


export type QueryCategoryArgs = {
  categoryId: Scalars['String'];
};


export type QueryGaugeArgs = {
  gaugeId: Scalars['String'];
};


export type QueryGaugesArgs = {
  subcategoryId?: Maybe<Scalars['String']>;
};


export type QuerySubcategoriesArgs = {
  categoryId?: Maybe<Scalars['String']>;
};


export type QuerySubcategoryArgs = {
  subcategoryId: Scalars['String'];
};


export type QueryTogglerArgs = {
  togglerId: Scalars['String'];
};


export type QueryTogglersArgs = {
  subcategoryId?: Maybe<Scalars['String']>;
};

export type Subcategory = {
  readonly __typename?: 'Subcategory';
  readonly category: Category;
  readonly categoryId: Scalars['String'];
  readonly gauges: ReadonlyArray<Gauge>;
  readonly id: Scalars['String'];
  readonly name: Scalars['String'];
  readonly rank: Scalars['Int'];
  readonly togglers: ReadonlyArray<Toggler>;
};

export type Subscription = {
  readonly __typename?: 'Subscription';
  readonly latestGaugeValue: GaugeValue;
  readonly latestLog: Log;
  readonly latestTogglerValue: TogglerValue;
};


export type SubscriptionLatestGaugeValueArgs = {
  gaugeId: Scalars['String'];
};


export type SubscriptionLatestTogglerValueArgs = {
  togglerId: Scalars['String'];
};

export type Toggler = {
  readonly __typename?: 'Toggler';
  readonly description: Scalars['String'];
  readonly id: Scalars['String'];
  readonly interactive: Scalars['Boolean'];
  readonly name: Scalars['String'];
  readonly physicalId: Scalars['String'];
  readonly rank: Scalars['Int'];
  readonly subcategory: Subcategory;
  readonly subcategoryId: Scalars['String'];
  readonly values: ReadonlyArray<TogglerValue>;
};

export enum TogglerStatus {
  Error = 'ERROR',
  Off = 'OFF',
  On = 'ON'
}

export type TogglerValue = {
  readonly __typename?: 'TogglerValue';
  readonly createdAt: Scalars['DateTime'];
  readonly id: Scalars['String'];
  readonly status: TogglerStatus;
  readonly togglerId: Scalars['String'];
};

export type UpdateCategoryInput = {
  readonly color: Scalars['String'];
  readonly id: Scalars['String'];
  readonly name: Scalars['String'];
  readonly rank: Scalars['Int'];
};

export type UpdateGaugeInput = {
  readonly description: Scalars['String'];
  readonly id: Scalars['String'];
  readonly interactive: Scalars['Boolean'];
  readonly name: Scalars['String'];
  readonly physicalId: Scalars['String'];
  readonly rank: Scalars['Int'];
  readonly subcategoryId: Scalars['String'];
  readonly type: GaugeType;
};

export type UpdateSubcategoryInput = {
  readonly categoryId: Scalars['String'];
  readonly id: Scalars['String'];
  readonly name: Scalars['String'];
  readonly rank: Scalars['Int'];
};

export type UpdateTogglerInput = {
  readonly description: Scalars['String'];
  readonly id: Scalars['String'];
  readonly interactive: Scalars['Boolean'];
  readonly name: Scalars['String'];
  readonly physicalId: Scalars['String'];
  readonly rank: Scalars['Int'];
  readonly subcategoryId: Scalars['String'];
};