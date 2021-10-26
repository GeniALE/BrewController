export default (query: string): Record<string, string> => {
  const pairs = (query[0] === '?' ? query.substr(1) : query).split('&')

  return pairs.reduce((result, pair) => {
    const [key, value] = pair.split('=')

    return {
      ...result,
      [decodeURIComponent(key)]: decodeURIComponent(value),
    }
  }, {})
}
