import Vue from 'vue';
import Vuex from 'vuex';

import { getField, updateField } from 'vuex-map-fields';

Vue.use(Vuex);

export default new Vuex.Store({
  strict: process.env.NODE_ENV !== 'production',
  state: {
    name: '',
    yearlySalary: 52000,
    numberOfPaychecksPerYear: 26,
    dependents: [],
    isLoading: false,
    results: null,
    error: null
  },
  mutations: {
    ADD_DEPENDENT(state) {
      state.dependents.push({ name: '', type: '' });
    },
    REMOVE_DEPENDENT(state, index) {
      state.dependents.splice(index, 1);
    },
    START_LOADING(state) {
      state.isLoading = true;
    },
    STOP_LOADING(state) {
      state.isLoading = false;
    },
    SET_RESULTS(state, results) {
      state.results = results;
    },
    CLEAR_RESULTS(state) {
      state.results = null;
    },
    SET_ERROR(state, error) {
      state.error = error;
    },
    updateField
  },
  actions: {
    addDependent({ commit }) {
      commit('CLEAR_RESULTS');
      commit('ADD_DEPENDENT');
    },
    removeDependent({ commit }, index) {
      commit('CLEAR_RESULTS');
      commit('REMOVE_DEPENDENT', index);
    },
    async calculateDeductions({ commit, state }) {
      commit('CLEAR_RESULTS');
      try {
        var response = await window.axios.post('/api/benefitscalculator', {
          Name: state.name,
          YearlySalary: state.yearlySalary,
          NumberOfPaychecksPerYear: state.numberOfPaychecksPerYear,
          Dependents: state.dependents
        });
        commit('SET_RESULTS', response.data);
      } catch (error) {
        commit('SET_ERROR', error);
      }
    }
  },
  getters: {
    getField
  }
});
