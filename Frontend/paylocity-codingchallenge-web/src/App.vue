<template>
  <v-app>
    <loading :active.sync="isLoading"></loading>
    <v-toolbar app>
      <v-toolbar-title class="headline text-uppercase">
        <span>Paylocity</span>&nbsp;
        <span class="font-weight-light">CODING CHALLENGE</span>
      </v-toolbar-title>
    </v-toolbar>

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
      <v-form ref="form">
        <v-container>
          <v-layout justify-center>
            <v-flex xs12 md9>
              <h4 class="headline">Employee</h4>
            </v-flex>
          </v-layout>
          <v-layout row wrap justify-center>
            <v-flex xs12 md3>
              <v-text-field label="Name" v-model="name" :rules="requiredRules"></v-text-field>
            </v-flex>
            <v-flex xs12 md3>
              <v-text-field
                label="Yearly Salary"
                v-model="yearlySalary"
                :rules="requiredRules"
                type="number"
              ></v-text-field>
            </v-flex>
            <v-flex xs12 md3>
              <v-text-field
                label="Number of Paychecks per Year"
                v-model="numberOfPaychecksPerYear"
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
          <v-layout row wrap justify-center v-for="(dependent, index) in dependents" :key="index">
            <v-flex xs12 md3>
              <v-text-field label="Name" v-model="dependent.name" :rules="requiredRules"></v-text-field>
            </v-flex>
            <v-flex xs12 md3>
              <v-select :items="dependentTypes" label="Type" v-model="dependent.type" :rules="requiredRules"></v-select>
            </v-flex>
            <v-flex xs12 md3 text-md-center>
              <v-btn @click="removeDependent(index)">Remove</v-btn>
            </v-flex>
          </v-layout>
        </v-container>
        <v-container>
          <v-layout row wrap justify-center>
            <v-flex xs12 md3>
              <v-btn block class="primary" @click="calculateDeductions">Calculate Deductions</v-btn>
            </v-flex>
          </v-layout>
        </v-container>
      </v-form>

      <Results :results="calculationResults"/>
    </v-content>
  </v-app>
</template>

<script>
import Results from './components/Results'
import Loading from 'vue-loading-overlay';
// Import stylesheet
import 'vue-loading-overlay/dist/vue-loading.css';

export default {
  name: "App",
  components: {
    Results,
    Loading
  },
  data: function () {
    return {
      name: "",
      yearlySalary: 52000,
      numberOfPaychecksPerYear: 26,
      dependents: [],
      dependentTypes: ['Spouse', 'Child'],
      requiredRules: [v => !!v || "Field is required"],
      error: null,
      calculationResults: null,
      isLoading: false
    };
  },
  methods: {
    addDependent: function () {
      this.dependents.push({ name: '', type: '' });
    },
    removeDependent: function (index) {
      this.dependents.splice(index, 1)
    },
    calculateDeductions: async function () {
      if (this.$refs.form.validate()) {
        try {
          this.isLoading = true;
          var response = await this.$axios.post("/api/benefitscalculator", {
            Name: this.name,
            YearlySalary: this.yearlySalary,
            NumberOfPaychecksPerYear: this.numberOfPaychecksPerYear,
            Dependents: this.dependents
          });
          this.calculationResults = response.data;
        } catch (error) {
          this.error = error;
        }
        this.isLoading = false;
      }
    }
  }
};
</script>
