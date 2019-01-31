<template>
  <v-app>
    <loading :active.sync="isLoading"></loading>
    <v-toolbar app>
      <v-toolbar-title class="headline text-uppercase">
        <span>Paylocity</span>&nbsp;
        <span class="font-weight-light">CODING CHALLENGE</span>
      </v-toolbar-title>
    </v-toolbar>

    <BenefitsCalculator />
  </v-app>
</template>

<script>
import BenefitsCalculator from './components/BenefitsCalculator';
import Loading from 'vue-loading-overlay';
import { mapState } from 'vuex';
// Import stylesheet
import 'vue-loading-overlay/dist/vue-loading.css';

export default {
  name: "App",
  components: {
    BenefitsCalculator,
    Loading
  },
  computed: mapState(['isLoading'])
};
</script>
