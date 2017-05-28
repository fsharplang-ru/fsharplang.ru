var path = require("path");
var webpack = require("webpack");
// var NpmInstallPlugin = require("npm-install-webpack-plugin");

function resolve(filePath) {
  return path.join(__dirname, filePath)
}

var babelOptions = {
  presets: [["es2015", { "modules": false }]],
  plugins: ["transform-runtime"]
};

var isProduction = process.argv.indexOf("-p") >= 0;
console.log("Bundling for " + (isProduction ? "production" : "development") + "...");

module.exports = {
  devtool: "source-map",
  entry: resolve('./fsharplangru-client.fsproj'),
  output: {
    filename: 'bundle.js',
    path: resolve('./public'),
  },
  // plugins: [
  //   new NpmInstallPlugin()
  // ],
  resolve: {
    modules: [
      "node_modules", resolve("./node_modules/")
    ]
  },
  devServer: {
    contentBase: resolve('./public'),
    port: 8080
  },
  module: {
    rules: [
      {
        test: /\.fs(x|proj)?$/,
        use: {
          loader: "fable-loader",
          options: {
            babel: babelOptions,
            define: isProduction ? [] : ["DEBUG"]
          }
        }
      },
      {
        test: /\.js$/,
        exclude: /node_modules/,
        use: {
          loader: 'babel-loader',
          options: babelOptions
        },
      },
      {
        test: /\.css$/,
        use: [
          "style-loader",
          "css-loader"
        ]
      },
      { test: /\.eot$/, loader: "file-loader" },
      { test: /\.svg$/, loader: "url-loader", options: { mimetype: "image/svg+xml" } },
      { test: /\.ttf$/, loader: "url-loader", options: { mimetype: "application/octet-stream" } },
      { test: /\.(woff|woff2)$/, loader: "url-loader", options: { mimetype: "application/font-woff" } },
    ]
  }
};
