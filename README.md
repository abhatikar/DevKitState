---
title: "DevKit State"
permalink: /docs/projects/devkit-state/
excerpt: "Monitor DevKit states and control the user LED with Azure IoT Hub device twins."
header:
  overlay_image: /assets/images/projects-iothub.jpg
  overlay_full: true
  teaser: /assets/images/projects-iothub-th.jpg
icons:
  - url: /assets/images/icon-iot-hub.svg
    target: https://azure.microsoft.com/en-us/services/iot-hub/
    title: IoT Hub
difficulty: EASY
last_modified_at: 2017-10-18
---

{% include toc icon="columns" %}

在这个实例中，你可以通过Azure IoT Hub device twins来监控MXChip IoT DevKit的WiFi信息和传感器状态，控制user LED。

## 开始

1. 根据[Get Started](https://microsoft.github.io/azure-iot-developer-kit/docs/get-started/)搭建开发环境
2. `git clone https://github.com/DevKitExamples/DevKitState.git`
3. `cd DevKitState`
4. `code .`

## 配置Azure服务

1. 点击Visual Stuio Code中的**任务**目录 - **运行任务…** - **cloud-provision**
2. 选择一个订阅
3. 选择或创建一个资源组（如果你已经创建了一个免费的IoT Hub，这一步会被跳过）
4. 选择或创建一个IoT Hub

## 为DevKit配置IoT Hub Device Connection String

1. 打开浏览器并输入：https://portal.azure.cn
2. 找到并进入我们刚才创建的Azure IoT Hub
3. 选择“Device Explorer”，然后选择“Add”，然后将设备名字命名为“AZ3166”（请确保该名字输入无误）。安全类型为“Symmetric key”，然后点Save创建
4. 点击Visual Stuio Code中的**任务**目录 - **运行任务…** - **config-device-connection**
3. 随后根据提示再次进入DevKit设置模式（首先按住A键，然后保持按住并同时按一下Reset键后放开Reset键。最后再放开A键），会自动将Connection string写入DevKit中

## 将Arduino Code上传到DevKit

1. 将DevKit连接到电脑上
2. 点击Visual Stuio Code中的**任务**目录 - **运行Build任务…**
3. 等待Arduino Code上传

## 在浏览器中监控DevKit状态

1. 在浏览器中打开https://vschina.github.io/devkit-state/
2. 填入IoT Hub connection string
3. 点击Connect按钮
4. 几秒后你会看到DevKit状态

## 控制User LED

1. 在网页上点击User LED
2. 几秒后你会看到user LED状态发生了变化

## 截图

![](https://raw.githubusercontent.com/DevKitExamples/DevKitState/master/screenshots/devkit-state.png)

{% include feedback.html tutorial="devkit-state" %}