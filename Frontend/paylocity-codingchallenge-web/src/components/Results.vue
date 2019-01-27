<template>
  <v-container v-if="results !== null" grid-list-lg>
    <v-layout justify-center>
      <v-flex xs12 md9>
        <h4 class="headline">Calculation Results</h4>
      </v-flex>
    </v-layout>
    <v-layout row wrap justify-center>
      <v-flex xs12 md3>
        <v-card>
          <v-card-title>
            <h3>Employee</h3>
          </v-card-title>
          <v-card-text>
            <p>Deduction Per Paycheck: {{ results.employeeDeductionPerPayCheck | currency }}</p>
            <p>Deduction Per Year: {{ results.employeeDeductionPerYear | currency }}</p>
          </v-card-text>
        </v-card>
      </v-flex>
      <v-flex xs12 md3 v-if="results.dependentsDeductionPerPayCheck !== 0">
        <v-card>
          <v-card-title>
            <h3>Dependents</h3>
          </v-card-title>
          <v-card-text>
            <p>Deduction Per Paycheck: {{ results.dependentsDeductionPerPayCheck | currency }}</p>
            <p>Deduction Per Year: {{ results.dependentsDeductionPerYear | currency }}</p>
          </v-card-text>
        </v-card>
      </v-flex>
      <v-flex xs12 md3>
        <v-card>
          <v-card-title>
            <h3>Total</h3>
          </v-card-title>
          <v-card-text>
            <p>Deduction Per Paycheck: {{ results.totalDeductionPerPayCheck | currency }}</p>
            <p>Deduction Per Year: {{ results.totalDeductionPerYear | currency }}</p>
          </v-card-text>
        </v-card>
      </v-flex>
    </v-layout>
    <v-layout row justify-center>
      <v-flex xs12 md9 text-md-center>
        <h5
          class="headline"
        >Employee paycheck after deductions: {{ results.employeePaycheckAfterDeductions | currency }}</h5>
        <h5
          class="headline"
        >Employee yearly pay after deductions: {{ results.employeeYearlyPayAfterDeductions | currency }}</h5>
      </v-flex>
    </v-layout>
  </v-container>
</template>

<script>
export default {
  props: ["results"]
};
</script>
