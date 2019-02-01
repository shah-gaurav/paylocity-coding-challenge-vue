<template>
  <v-content>
    <v-container>
      <v-layout>
        <v-flex class="text-md-center" xs12 md6 offset-md3>
          <h1 class="display-1">Employee Benefits Deduction Calculator</h1>
          <p
            class="subheading"
          >Enter the employee's information below to calculate their benefits deduction</p>
        </v-flex>
      </v-layout>
    </v-container>

    <Employee />

    <Results :results="results"/>
  </v-content>
</template>

<script>
import Employee from './Employee';
import Results from './Results';
import { mapState } from 'vuex';

export default {
  components: {
    Employee,
    Results
  },
  computed: mapState(['results'])
}
</script>

