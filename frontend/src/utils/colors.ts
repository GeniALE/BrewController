const randomInt = (min: number, max: number): number => {
  return Math.floor(Math.random() * (max - min + 1)) + min
}

export const possibleColors = [
  'red',
  'yellow',
  'green',
  'cyan',
  'blue',
  'magenta',
] as const

type Color = typeof possibleColors[number]

const hues: Record<Color, () => number> = {
  red: () => randomInt(0, 60),
  yellow: () => randomInt(60, 120),
  green: () => randomInt(120, 180),
  cyan: () => randomInt(180, 240),
  blue: () => randomInt(240, 300),
  magenta: () => randomInt(300, 360),
}

const decToHex = (val: number): string => {
  const hexResult = val.toString(16)

  return hexResult.length == 1 ? `0${hexResult}` : hexResult
}

const hslToHex = (hue: number, saturation: number, lightness: number): string => {
  saturation /= 100
  lightness /= 100

  const chroma = (1 - Math.abs(2 * lightness - 1)) * saturation
  const x = chroma * (1 - Math.abs((hue / 60) % 2 - 1))
  const lightness2 = lightness - chroma / 2
  let rgb = [0, 0, 0]

  if (hue < 60) {
    rgb = [chroma, x, 0]
  } else if (60 <= hue && hue < 120) {
    rgb = [x, chroma, 0]
  } else if (120 <= hue && hue < 180) {
    rgb = [0, chroma, x]
  } else if (180 <= hue && hue < 240) {
    rgb = [0, x, chroma]
  } else if (240 <= hue && hue < 300) {
    rgb = [x, 0, chroma]
  } else if (300 <= hue && hue < 360) {
    rgb = [chroma, 0, x]
  }

  const [red, green, blue] = rgb
  const hexRed = decToHex(Math.round((red + lightness2) * 255))
  const hexGreen = decToHex(Math.round((green + lightness2) * 255))
  const hexBlue = decToHex(Math.round((blue + lightness2) * 255))

  return `#${hexRed}${hexGreen}${hexBlue}`
}

export const generateColor = (color: Color | false = false) => {
  const hue = color ? hues[color]() : randomInt(0, 360)
  const saturation = randomInt(50, 98)
  const lightness = randomInt(40, 90)

  return hslToHex(hue, saturation, lightness)
}
