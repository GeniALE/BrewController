import type { Writable } from 'svelte/store'
import { tick } from 'svelte'
import { writable } from 'svelte/store'

let modalContainer: HTMLElement | undefined = undefined
export const destroyModal: Writable<(() => void) | undefined> = writable(undefined)

export const setModalContainer = (container: HTMLElement) => {
  modalContainer = container
  modalContainer.style.display = 'none'

  return {
    destroy: () => {
      modalContainer = undefined
    },
  }
}

const mount = (node: HTMLElement) => {
  if (typeof modalContainer === 'undefined') {
    throw 'unknown modal container'
  }

  modalContainer.insertBefore(node, null)
  modalContainer.style.display = 'flex'

  return () => {
    if (modalContainer.contains(node)) {
      // modalContainer.removeChild(node)
      modalContainer.style.display = 'none'
      destroyModal.set(undefined)
    }
  }
}

export const modal = (node: HTMLElement, onDestroy: () => void) => {
  let destroy: () => void

  if (typeof modalContainer !== 'undefined') {
    void tick().then(() => {
      destroy = mount(node)
    })
  } else {
    destroy = mount(node)
  }

  const closeModal = () => {
    onDestroy()
    destroy()
  }

  destroyModal.set(closeModal)

  return {
    destroy: closeModal,
  }
}
