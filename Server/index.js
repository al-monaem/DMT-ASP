const express = require('express')
const app = express()
const fs = require("fs");

const https = require('https')
const { Server } = require('socket.io')

const server = https.createServer({
    key: fs.readFileSync("C:/Users/Bishop/key.pem"),
    cert: fs.readFileSync("C:/Users/Bishop/cert.pem"),
    requestCert: false,
    rejectUnauthorized: false
}, app)

const cors = require("cors")
const port = "3001"
const ip = "192.168.0.104"

app.use(cors())

const io = new Server(server, {
    cors: {
        origin: "*"
    },
    secure: true
})

io.on("connection", (socket) => {

    //console.log("user connected ", socket.id)

    socket.on("send", (data) => {
        console.log(data)

        io.broadcast.emit("brodcast", data)
    })
})

server.listen(port, ip, () => {
    console.log(`Listening to requests on https://localhost:${port}`);
});