// Give the service worker access to Firebase Messaging.
// Note that you can only use Firebase Messaging here. Other Firebase libraries
// are not available in the service worker.
importScripts('https://www.gstatic.com/firebasejs/8.6.7/firebase-app.js');
importScripts('https://www.gstatic.com/firebasejs/8.6.7/firebase-messaging.js');

// Initialize the Firebase app in the service worker by passing in
// your app's Firebase config object.
// https://firebase.google.com/docs/web/setup#config-object
firebase.initializeApp({
    databaseURL: "https://chromenotification-725ba-default-rtdb.asia-southeast1.firebasedatabase.app",
    apiKey: "AIzaSyCFiNWVO9qQaxbdxmd7Y2wbVW-yMBvd6u0",
    authDomain: "chromenotification-725ba.firebaseapp.com",
    projectId: "chromenotification-725ba",
    storageBucket: "chromenotification-725ba.appspot.com",
    messagingSenderId: "235890289713",
    appId: "1:235890289713:web:d8a500bd63d0be6d4ff910",
    measurementId: "G-PFPZRR0Y7X"
});

// Retrieve an instance of Firebase Messaging so that it can handle background
// messages.
const messaging = firebase.messaging();

messaging.onBackgroundMessage((payload) => {
    console.log('[firebase-messaging-sw.js] Received background message ', payload);
});