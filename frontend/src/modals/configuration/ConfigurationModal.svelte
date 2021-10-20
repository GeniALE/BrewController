<script lang="ts">
  import { Title, Content, Actions } from '@smui/dialog'
  import List, { Separator } from '@smui/list'
  import Modal from 'components/Modal.svelte'
  import { mdiSpeedometer, mdiToggleSwitch, mdiShape, mdiChartLine, mdiPalette, mdiLightningBolt } from '@mdi/js'
  import SideMenuItem from 'components/SideMenuItem.svelte'
</script>

<Modal>
  <Title>Dialog title</Title>
  <Content>
    <div class="content">
      <div class="sidemenu">
        <List>
          <SideMenuItem icon={mdiSpeedometer}>Gauges</SideMenuItem>
          <SideMenuItem icon={mdiToggleSwitch}>Togglers</SideMenuItem>
          <SideMenuItem icon={mdiShape}>Categories</SideMenuItem>
          <Separator />
          <SideMenuItem icon={mdiChartLine}>Charts</SideMenuItem>
          <Separator />
          <SideMenuItem icon={mdiLightningBolt}>Actions</SideMenuItem>
          <SideMenuItem icon={mdiPalette}>Appearance</SideMenuItem>
        </List>
      </div>
      <div class="configuration">

      </div>
    </div>
  </Content>
  <Actions>
    <button>hello</button>
  </Actions>
</Modal>

<style lang="scss">
</style>
