<script lang="ts">
  export let size = 24
  export let color = '#000000'
  export let path: string
</script>

<svg viewBox="0 0 24 24"  style={`min-width: ${size}px; min-height: ${size}px; width: ${size}px; height: ${size}px;`}>
  <path style={`fill: ${color};`} d={path} />
</svg>
