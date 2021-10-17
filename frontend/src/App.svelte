<script>
	import ActionsContainer from 'containers/ActionsContainer.svelte'
	import CurrentlyContainer from 'containers/CurrentlyContainer.svelte'
	import LogsContainer from 'containers/LogsContainer.svelte'
	import svelteClient from 'utils/urql'
	import { setClient } from '@urql/svelte'

	setClient(svelteClient)
</script>

<main>
	<ActionsContainer />
	<CurrentlyContainer />
	<LogsContainer />
</main>

<style lang="scss">
	main {
		font-family: 'Roboto', sans-serif;
		background: #bdbdbd;
		width: 100vw;
		height: 100vh;
		display: grid;
		column-gap: 1px;
		row-gap: 1px;
		grid-template-columns: 4fr 3.5fr 40%;
		grid-template-rows: 3.5fr 1.5fr;
		grid-template-areas:
			'logs currently charts'
			'side currently charts';
	}
</style>
