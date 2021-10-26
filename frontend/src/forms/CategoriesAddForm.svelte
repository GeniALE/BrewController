<script lang="ts">
  import { mutation } from '@urql/svelte'
  import { Button, ButtonSet, Form, FormGroup, TextInput } from 'carbon-components-svelte'
  import Title from 'components/Title.svelte'
  import { AddNewCategoryDocument } from 'generated/operations'
  import type { AddNewCategoryMutation, AddNewCategoryMutationVariables } from 'generated/queries'
  import type { AddCategoryInput } from 'generated/schema'
  import { useNavigate } from 'svelte-navigator'
  import { isNullOrEmpty } from 'utils/isNullOrEmpty'

  let name: string
  let color: string

  const navigate = useNavigate()

  const addCategory = mutation<AddNewCategoryMutation, AddNewCategoryMutationVariables>({
    query: AddNewCategoryDocument,
  })

  const submit = async () => {
    const newCategory: AddCategoryInput = {
      name,
      color,
    }

    try {
      await addCategory({
        newCategory,
      })

      navigate('/settings/categories')
    } catch (error) {
      alert(error)
    }
  }
</script>

<Title>Add Category</Title>

<Form on:submit={submit}>
  <FormGroup>
    <TextInput size="xl" labelText="Name" bind:value={name} />
  </FormGroup>
  <FormGroup>
    <TextInput size="xl" labelText="Color" bind:value={color} />
  </FormGroup>
  <ButtonSet>
    <Button kind="secondary" on:click={() => navigate('/settings/categories')}>Cancel</Button>
    <Button type="submit" disabled={[name, color].some(isNullOrEmpty)}>Submit</Button>
  </ButtonSet>
</Form>
