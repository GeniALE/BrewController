import { tick } from 'svelte'

let modalContainer: HTMLElement | undefined = undefined
export let closeModal: () => void | undefined = undefined

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
      closeModal = undefined
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

  closeModal = () => {
    onDestroy()
    destroy()
  }

  return {
    destroy: closeModal,
  }
}
