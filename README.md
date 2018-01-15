---
title: "DevKit State"
permalink: /docs/projects/devkit-state/
excerpt: "Monitor DevKit states and control the user LED with Azure IoT Hub device twins."
header:
  overlay_image: https://raw.githubusercontent.com/DevKitExamples/DevKitState/master/devkit-state.jpg
  overlay_full: true
  teaser: https://raw.githubusercontent.com/DevKitExamples/DevKitState/master/devkit-state-th.jpg
icons:
  - url: /assets/images/icon-iot-hub.svg
    target: https://azure.microsoft.com/en-us/services/iot-hub/
    title: IoT Hub
difficulty: EASY
last_modified_at: 2017-10-18
---

{% include toc icon="columns" %}

You can use this example to monitor MXChip IoT DevKit states and control the user LED with Azure IoT Hub device twins, including WiFi information and sensor states.

## Steps to start

1. Setup development environment by following [Get Started](https://microsoft.github.io/azure-iot-developer-kit/docs/get-started/)
2. `git clone https://github.com/DevKitExamples/DevKitState.git`
3. `cd DevKitState`
4. `code .`

## Provision Azure Services

1. Click **Task** menu in Visual Studio Code - **Run Task...** - **cloud-provision**
2. Select a subscription
3. Select or choose a resource group (if you have already had a free IoT Hub, this step will be skipped)
4. Select or create an IoT Hub
5. You will see something like *function app: function app name: xxx*, write down the function app name, and we will use it in later step
6. Wait for ARM template deployment

## Deploy Function App

1. Click **Task** menu in Visual Studio Code - **Run Task...** - **cloud-deploy**
2. Wait for function app code uploading

## Configure IoT Hub Device Connection String in DevKit

1. Connect your DevKit to your machine
2. Click **Task** menu in Visual Studio Code - **Run Task...** - **config-device-connection**
3. Hold button A on DevKit, then press rest button, and then release button A to enter config mode
4. Wait for connection string configuration

## Uploade Arduino Code to DevKit

1. Connect your DevKit to your machine
2. Click **Task** menu in Visual Studio Code - **Run Build Task...**
3. Wait for arduino code uploading

## Monitor DevKit State in Browser

1. Open `DevKitState\web\index.html` in browser
2. Input the function app name you write down
3. Click connect button
4. You should see DevKit state in few seconds

## Control DevKit User LED

1. Click User LED on the web page
2. You should see user LED state changed in few seconds

## Screenshots

![](https://raw.githubusercontent.com/DevKitExamples/DevKitState/master/screenshots/devkit-state.gif)

{% include feedback.html tutorial="devkit-state" %}