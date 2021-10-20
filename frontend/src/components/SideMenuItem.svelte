<script lang="ts">
  import { Item, Text } from '@smui/list'
  import Icon from 'components/Icon.svelte'

  export let icon: string
  export let selected = false
</script>

<Item on:SMUI:action {selected}>
  <div class="item">
    <Icon path={icon} />
    <Text><slot/></Text>
  </div>
</Item>

<style lang="scss">
  .item {
    display: flex;
    column-gap: 4px;
  }
</style>
