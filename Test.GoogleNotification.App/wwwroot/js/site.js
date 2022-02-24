$(document).ready(function () {

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

    const messaging = firebase.messaging();
    // Add the public key generated from the console here.
    messaging.usePublicVapidKey('BCjOMNqmqEYVn9E8xmyn4Sw83ea03lrp97lPCfaBt107hf8plyP4Ok0LDMY5rdaTm9_DXxGODMq5iXB1PTQi6wA');

    messaging.onTokenRefresh(() => {
        messaging.getToken().then((refreshedToken) => {
            getFirebaseToken();
        }).catch((err) => {
            console.log('Unable to retrieve refreshed token ', err);
        });
    });

    messaging.onMessage((payload) => {
        console.log('onMessage Received background message ', payload);
    });

    function requestPermission() {
        if (!window.Notification) {
            alert("Your browser not supprot notify");
            cookie_manager.set_cookie("subscribe_site", "1", 10);
        } else {
            Notification.requestPermission().then((permission) => {
                if (permission === 'granted') {
                    getFirebaseToken();
                } else {
                    cookie_manager.set_cookie("subscribe_site", "1", 10);
                }
            });
        }
    }

    function getFirebaseToken() {
        messaging.getToken().then((currentToken) => {
            if (currentToken) {
                console.log(currentToken);
                // Call APi to update data into DB
                $.ajax({
                    url: "/user/create",
                    data: { "SubscribeToken": currentToken },
                    dataType: "JSON",
                    method: "POST",
                    success: function (data) {
                        cookie_manager.set_cookie("subscribe_site", "1", 10);
                        window.location.href = "/";
                    }
                });
            } else {
                requestPermission();
            }
        }).catch((err) => {
            console.log('An error occurred while retrieving token. ', err);
        });
    }

    $("#btnSubscribe").click(function () {
        requestPermission();
    });

});