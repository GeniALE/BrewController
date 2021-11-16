<script lang="ts">
  import { AddNewGaugeDocument, GetGaugeByIdDocument, GetGaugesDocument, UpdateGaugeDocument } from 'generated/operations'
  import { mutation, operationStore, query } from '@urql/svelte'
  import type { AddNewGaugeMutation, AddNewGaugeMutationVariables, GetGaugeByIdQuery, GetGaugeByIdQueryVariables, GetGaugesQuery, GetGaugesQueryVariables, UpdateGaugeMutation, UpdateGaugeMutationVariables } from 'generated/queries'

  import type { AddGaugeInput, UpdateGaugeInput } from 'generated/schema'
  import { GaugeType } from 'generated/schema'
  import { useNavigate } from 'svelte-navigator'
  import Title from 'components/Title.svelte'
  import { Button, ButtonSet, Dropdown, DropdownSkeleton, Form, FormGroup, TextInput, TextInputSkeleton } from 'carbon-components-svelte'
  import { isNullOrEmpty } from 'utils/isNullOrEmpty'


  export let gaugeId: string | undefined
  const isEditing = typeof gaugeId !== 'undefined'
  let name: string
  let description : string
  let interactive : boolean
  let categoryId : string
  let done = false
  let nodeId : string
  let gaugeTypeIndex=0
  const gaugeTypeOptions = [
    { id: GaugeType.Temperature, text: 'Temperature' },
    { id: GaugeType.Pressure, text: 'Pressure' },
  ]

  const gaugeTypeDict : Record<GaugeType,number> = {
    [GaugeType.Temperature]:0,
    [GaugeType.Pressure]:1,
  }

  const navigate = useNavigate()

  const currentGauge = operationStore<GetGaugeByIdQuery, GetGaugeByIdQueryVariables>(GetGaugeByIdDocument, { id: categoryId }, { pause: !isEditing })
  const gauges = operationStore<GetGaugesQuery, GetGaugesQueryVariables>(GetGaugesDocument)

  const addGauge = mutation<AddNewGaugeMutation, AddNewGaugeMutationVariables>({
    query: AddNewGaugeDocument,
  })

  const updateCategory = mutation<UpdateGaugeMutation, UpdateGaugeMutationVariables>({
    query: UpdateGaugeDocument,
  })

  const submit = async () => {
    try {
      if (isEditing) {
        const updatedGauge: UpdateGaugeInput = {
          id: gaugeId,
          name,
          description,
          type: gaugeTypeOptions[gaugeTypeIndex].id,
          interactive,
          nodeId,
          categoryId,
        }

        await updateCategory({
          updatedGauge,
        })
      } else {
        const newGauge: AddGaugeInput = {
          name,
          description,
          type: gaugeTypeOptions[gaugeTypeIndex].id,
          interactive,
          nodeId,
          categoryId,
        }

        const ranking = $gauges.data.gauges.length === 0 ? {} : {
          previousId: $gauges.data.gauges[$gauges.data.gauges.length - 1].id,
        }
        await addGauge({
          newGauge,
          ranking,
        })
      }

      navigate('/settings/gauges')
    } catch (error) {
      alert(error)
    }
  }

  $: if (!$currentGauge.fetching && $currentGauge.data && !done && isEditing) {
    name = $currentGauge.data.gauge.name
    description = $currentGauge.data.gauge.description
    interactive = $currentGauge.data.gauge.interactive
    nodeId = $currentGauge.data.gauge.nodeId
    categoryId = $currentGauge.data.gauge.categoryId
    gaugeTypeIndex = gaugeTypeDict[$currentGauge.data.gauge.type]
    done = true
  }

  query(currentGauge)
  query(gauges)
</script>

<Title>{isEditing ? 'Edit' : 'Add'} Gauge <span class="title-name">{name}</span></Title>

<Form on:submit={submit}>
  <FormGroup>
    {#if $currentGauge.fetching}
      <TextInputSkeleton />
    {:else}
      <TextInput size="xl" labelText="Name" bind:value={name} />
    {/if}
  </FormGroup>
  <FormGroup>
    {#if $currentGauge.fetching}
      <TextInputSkeleton />
      <TextInputSkeleton />
      <DropdownSkeleton />
      <DropdownSkeleton />
    {:else}
      <TextInput size="xl" labelText="Description" bind:value={description} />
      <TextInput size="xl" labelText="nodeId" bind:value={nodeId} />
      <Dropdown size="xl" titleText="GaugeType" items={gaugeTypeOptions} bind:selectedIndex={gaugeTypeIndex} />


    {/if}
  </FormGroup>
  <ButtonSet>
    <Button kind="secondary" on:click={() => navigate('/settings/categories')}>Cancel</Button>
    <Button type="submit" disabled={[name].some(isNullOrEmpty)}>Submit</Button>
  </ButtonSet>
</Form>

<!-- INPUT TODO -->
<!--
type = $currentGauge.data.gauge.type
categoryId = $currentGauge.data.gauge.categoryId

interactive = $currentGauge.data.gauge.interactive
-->

