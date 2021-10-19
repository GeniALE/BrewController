import { writable } from 'svelte/store'

const modalList = [
  // modals
  'configuration',
  'controlPanel',
] as const

type ModalList = typeof modalList[number]

export const activeModal = writable<ModalList | undefined>()
