<template>
    <v-layout
        row
        wrap
        justify-center        
      >
        <v-flex xs12 md3>
          <v-text-field label="Name" v-model="dependent.name" :rules="requiredRules"></v-text-field>
        </v-flex>
        <v-flex xs12 md3>
          <v-select
            :items="dependentTypes"
            label="Type"
            v-model="dependent.type"
            :rules="requiredRules"
          ></v-select>
        </v-flex>
        <v-flex xs12 md3 text-md-center>
          <v-btn @click="removeDependent(index)">Remove</v-btn>
        </v-flex>
      </v-layout>
</template>

<script>
import { mapActions } from 'vuex';

export default {
  props: ["dependent", "index"],
  data: function () {
    return {
      dependentTypes: ['Spouse', 'Child'],
      requiredRules: [v => !!v || "Field is required"],
    };
  },
  methods: mapActions(['removeDependent'])
}
</script>
