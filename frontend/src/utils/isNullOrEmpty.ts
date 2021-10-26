type Item = string | undefined | null

export const isNullOrEmpty =  (item: Item) => item === null || typeof item === 'undefined' || item === ''
