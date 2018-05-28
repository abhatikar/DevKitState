---
title: 'Use Azure device twins to control MXChip IoT DevKit user LED | Microsoft Docs'
description: In this tutorial, learn how to monitor DevKit states and control the user LED with Azure IoT Hub device twins.
services: iot-hub
documentationcenter: ''
author: liydu
manager: timlt
tags: ''
keywords: ''

ms.service: iot-hub
ms.devlang: arduino
ms.topic: article
ms.tgt_pltfrm: na
ms.workload: na
ms.date: 04/04/2018
ms.author: liydu
---

# MXChip IoT DevKit

You can use this example to monitor the MXChip IoT DevKit WiFi information and sensor states and to control the color of the user LED using Azure IoT Hub device twins.

## What you learn

- How to monitor the MXChip IoT DevKit sensor states.
- How to use Azure device twins to control the color of the DevKit's RGB LED.

## What you need

- Set up your development environment by following the [Getting Started Guide](https://docs.microsoft.com/azure/iot-hub/iot-hub-arduino-iot-devkit-az3166-get-started).
- Download **DevKit State** from IoT Workbench Examples.
  * Open VS Code and open command palette using `F1` (or `Ctrl` + `Shift` + `P` on Windows, `Command` + `Shift` + `P` on macOS), execute **IoT Workbench: Examples**.
  * Select **IoT DevKit**, example gallery will open in a new tab.
  * Find **DevKit State** and click **Open Sample** button.

## Provision Azure Services

1. Open VS Code command palette and execute **IoT Workbench: Cloud** command.
2. Select **Azure Provision**.
3. Follow the guide to log in to Azure and finish the provisioning process.
4. When VSCode asks you to enter a globally unique name for the new Function App, input a function app name. Write down the function app name; it will be used in a later step.

## Deploy Function App

1. Open VS Code command palette and execute **IoT Workbench: Cloud** command.
2. Select **Azure Deploy**.
2. Wait for function app code uploading process to finish.

## Configure IoT Hub Device Connection String in DevKit

1. Open VS Code command palette and execute **IoT Workbench: Device** command.
2. Select **Config Device Settings**.
3. Click **Select IoT Hub Device Connection String**.
4. On the MXChip IoT DevKit, press and hold button **A**, press the **Reset** button, and then release button **A** to make the DekKit enter configuration mode.
5. Wait for connection string configuration process to be completed.

## Upload Arduino Code to DevKit

With your MXChip IoT DevKit connected to your computer:
1. Open VS Code command palette and execute **IoT Workbench: Device** command.
2. Select **Device Upload**.
3. When the sketch has been uploaded successfully, a *Build & Upload Sketch: success* message is displayed.

## Monitor DevKit State in Browser

1. In a Web browser, open the `DevKitState\web\index.html` file--which was created during the [What you need](#whatyouneed) step.
2. The following Web page appears:![Specify the function app name.](https://docs.microsoft.com/en-us/azure/iot-hub/media/iot-hub-arduino-iot-devkit-az3166-devkit-state/devkit-state-function-app-name.png)
1. Input the function app name you wrote down earlier.
2. Click the **Connect** button
3. Within a few seconds, the page refreshes and displays the DevKit's WiFi connection status and the state of each of the onboard sensors.

## Control the DevKit's User LED

1. Click the user LED graphic on the Web page illustration.
2. Within a few seconds, the screen refreshes and shows the current color status of the user LED.
3. Try changing the color value of the RGB LED by clicking in various locations on the RGB slider controls.

## Example operation

![Example test procedure](https://docs.microsoft.com/en-us/azure/iot-hub/media/iot-hub-arduino-iot-devkit-az3166-devkit-state/devkit-state.gif)

> [!NOTE]
> You can see raw data of device twin in Azure portal:
> IoT Hub -\> IoT devices -\> *\<your device\>* -\> Device Twin.

## Next steps

You have learned how to:
- Connect an MXChip IoT DevKit device to your Azure IoT Remote Monitoring solution accelerator.
- Use the Azure IoT device twins function to sense and control the color of the DevKit's RGB LED.

Here are the suggested next steps:

* [Azure IoT Remote Monitoring solution accelerator overview](https://docs.microsoft.com/azure/iot-suite/)
* [Connect an MXChip IoT DevKit device to your Azure IoT Central application](https://docs.microsoft.com/microsoft-iot-central/howto-connect-devkit)