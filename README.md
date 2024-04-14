![DL Count](https://img.shields.io/github/downloads/turtle-insect/FF1/total.svg)
[![Build status](https://ci.appveyor.com/api/projects/status/1k21y30scaimi97w?svg=true)](https://ci.appveyor.com/project/turtle-insect/ff1)

# 概要
3DS ファイナルファンタジーのセーブデータ編集Tool

# ソフト
https://www.nintendo.co.jp/titles/50010000028215

# 実行に必要
* Windows マシン
* .NET Framework 4.8の導入
* セーブデータの吸い出し
* セーブデータの書き戻し

# Build環境
* Windows 10(64bit)
* Visual Studio 2017

# 編集時の手順
* saveDataを吸い出す
   * 結果、以下が取得可能
      * SAVE.BIN
* SAVE.BINを読み込む
* 任意の編集を行う
* SAVE.BINを書き出す
* saveDataを書き戻す
