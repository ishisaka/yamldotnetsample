# YamlDotNetの使用サンプル

2012-12-08 Tadahiro Ishisaka

## はじめに

これはC# Advent Calendar 2012 12月9日分、C#でYAMLを使えるか試してみたのサンプルコードです。

## 作業環境など

作業環境はVisual Studio 2012 Ultimateです。ただし内容的にはそれ以下のエディション、Expressエディションでも基本大丈夫なはずです。

また、[YamlDotNet](https://github.com/aaubry/YamlDotNet)のインストールと参照設定が必要ですので、NuGetで以下の3つを入手して下さい。

[YamlDotNet.Core](http://nuget.org/packages/YamlDotNet.Core)

[YamlDotNet.RepresentationModel](http://nuget.org/packages/YamlDotNet.RepresentationModel)

[YamlDotNet.Converters](http://nuget.org/packages/YamlDotNet.Converters)

## ディレクトリの構成

### CsAdventCalendarDec9Serialize

.NETのオブジェクトからYAMLへ変換するサンプル。

### CsAdventCalendarDec9DeSerialize

YAMLのファイルから.NETのオブジェクトへ復元を行うサンプル
