<script lang="ts">
  import { Title, Content, Actions } from '@smui/dialog'
  import List, { Item, Text } from '@smui/list'
  import Icon from 'components/Icon.svelte'
  import Modal from 'components/Modal.svelte'
  import { mdiSpeedometer } from '@mdi/js'
</script>

<Modal>
  <Title>Dialog title</Title>
  <Content>
    <div class="sidemenu">
      <List>
        <Item>
          <Icon path={mdiSpeedometer} />
          <Text>Gauges</Text>
        </Item>
      </List>
    </div>
  </Content>
  <Actions>
    <button>hello</button>
  </Actions>
</Modal>
