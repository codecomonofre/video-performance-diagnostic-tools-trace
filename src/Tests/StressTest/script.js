import http from 'k6/http';
import { check } from 'k6';

export let options = {
  stages: [
    { duration: '30s', target: 200 } // Simulate 200 users for 1 minute
  ],
};

export default function () {
  // let response = http.get('http://localhost:5000/orders-slow', {
  let response = http.get('http://localhost:5000/orders-fast', {
    // let response = http.get('https://localhost:7285/orders-fast', {
// let response = http.get('https://localhost:7285/orders-slow', {
    headers: {
      'accept': 'application/json',
    },
  });

  // Check if the request was successful
  check(response, {
    'status is 200': (r) => r.status === 200,
  });
}