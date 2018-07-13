const path = require('path');
const webpack = require('webpack');
const UglifyJSPlugin = require('uglifyjs-webpack-plugin');
const HtmlWebpackPlugin = require('html-webpack-plugin');
const ExtractTextPlugin = require('extract-text-webpack-plugin');
module.exports = {
    entry: {
        'polyfills': './app/polyfills.ts',
        'app': './app/main.ts'
      },
   output:{
       path: path.resolve(__dirname, 'dist'),
       publicPath: '/',
       filename: '[name].[hash].js'
   },
   devServer: {
    historyApiFallback: true,
  },
   resolve: {
    extensions: ['.ts', '.js']
  },
   module:{
       rules:[
           {
               test: /\.ts$/,
               use: [
                {
                    loader: 'awesome-typescript-loader',
                    options: { configFileName: path.resolve(__dirname, 'tsconfig.json') }
                  } ,
                   'angular2-template-loader'
               ]
            }, {
              test: /\.html$/,
              loader: 'html-loader'
            },{
            test: /\.(png|jpe?g|gif|svg|woff|woff2|ttf|eot|ico)$/,
            loader: 'file-loader?name=assets/[name].[hash].[ext]'
          },{
            test: /\.css$/,
            exclude: path.resolve(__dirname, 'app'),
            use: ExtractTextPlugin.extract({ fallback: "style-loader", use: "css-loader"})
          },{
            test: /\.css$/,
            include: path.resolve(__dirname, 'app'),
            loader: 'raw-loader'
          }
       ]
   },
   plugins: [
    new webpack.ContextReplacementPlugin(
        /angular(\\|\/)core/,
        path.resolve(__dirname, ''),
      {}
    ),
    new webpack.optimize.CommonsChunkPlugin({
        name: ['app', 'polyfills']
    }),
    new HtmlWebpackPlugin({
      template: 'index.html'
    }),
    new UglifyJSPlugin(),
    new ExtractTextPlugin('[name].[hash].css'),
    new webpack.NoEmitOnErrorsPlugin(),
    new webpack.LoaderOptionsPlugin({
      htmlLoader: {
        minimize: false
      }
    })
  ]
}