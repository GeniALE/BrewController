<script lang="ts">
  import { Column, Grid, Row } from 'carbon-components-svelte'
  import { ColorPalette24, Meter24, RadioButtonChecked24, UvIndex24 } from 'carbon-icons-svelte'
  import BigTile from 'components/BigTile.svelte'
</script>
<Grid>
  <Row>
    <Column noGutter aspectRatio="2x1" lg={6}>
      <BigTile href="/settings/gauges">
        <span slot="title">Gauges</span>
        <Meter24 slot="action" />
      </BigTile>
    </Column>
    <Column noGutter aspectRatio="2x1" lg={6}>
      <BigTile href="/settings/categories">
        <span slot="title">Categories</span>
        <UvIndex24 slot="action" />
      </BigTile>
    </Column>
  </Row>
  <Row>
    <Column noGutter aspectRatio="2x1" lg={6}>
      <BigTile href="/settings/togglers">
        <span slot="title">Togglers</span>
        <RadioButtonChecked24 slot="action" />
      </BigTile>
    </Column>
    <Column noGutter aspectRatio="2x1" lg={6}>
      <BigTile href="/settings/appearance">
        <span slot="title">Appearance</span>
        <ColorPalette24 slot="action" />
      </BigTile>
    </Column>
  </Row>
</Grid>
