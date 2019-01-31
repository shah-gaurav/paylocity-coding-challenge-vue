<template>
  <v-form ref="form">
    <v-container>
      <v-layout justify-center>
        <v-flex xs12 md9>
          <h4 class="headline">Employee</h4>
        </v-flex>
      </v-layout>
      <v-layout row wrap justify-center>
        <v-flex xs12 md3>
          <v-text-field label="Name" v-model="employee.name" :rules="requiredRules"></v-text-field>
        </v-flex>
        <v-flex xs12 md3>
          <v-text-field
            label="Yearly Salary"
            v-model="employee.yearlySalary"
            :rules="requiredRules"
            type="number"
          ></v-text-field>
        </v-flex>
        <v-flex xs12 md3>
          <v-text-field
            label="Number of Paychecks per Year"
            v-model="employee.numberOfPaychecksPerYear"
            :rules="requiredRules"
            type="number"
          ></v-text-field>
        </v-flex>
      </v-layout>
    </v-container>
    <v-container>
      <v-layout justify-center>
        <v-flex xs12 md9>
          <h4 class="headline">Dependents
            <v-btn small flat fab icon class="primary" @click="addDependent">
              <v-icon>add</v-icon>
            </v-btn>
          </h4>
        </v-flex>
      </v-layout>
      <Dependent
        v-for="(dependent, index) in employee.dependents"
        :key="index"
        :dependent="dependent"
        :index="index"
      />
    </v-container>
    <v-container>
      <v-layout row wrap justify-center>
        <v-flex xs12 md3>
          <v-btn block class="primary" @click="calculateDeductions">Calculate Deductions</v-btn>
        </v-flex>
      </v-layout>
    </v-container>
  </v-form>
</template>

<script>
import Dependent from './Dependent';
import { mapActions } from 'vuex';

export default {
  components: {
    Dependent
  },
  props: ["employee"],
  data: function () {
    return {
      requiredRules: [v => !!v || "Field is required"]
    };
  },
  methods: {
    ...mapActions(['addDependent']),
    calculateDeductions: async function () {
      if (this.$refs.form.validate()) {
        this.$store.commit('START_LOADING')
        await this.$store.dispatch('calculateDeductions');
        this.$store.commit('STOP_LOADING')
      }
    }
  }
}
</script>
