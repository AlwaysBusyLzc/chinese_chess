package main

import (
	"net"
	"fmt"
	"time"
	//"io/ioutil"
)

var (
	startTime int64
)

func main() {
	ln, err := net.Listen("tcp", ":9001")
	if err != nil {
		fmt.Println("Listen err", err)
		return
	}

	// 开一个协程去接受连接 然后为每一个已连接socket创建一个read协程 一个write协程
	go Listen(ln)

	var input string
	fmt.Scanln(&input)
	fmt.Println("i am input ", input)
}

func Listen(ln net.Listener) {
	// 循环接受连接
	connectCount := 0
	for {
		conn, err := ln.Accept()
		if err != nil {
			fmt.Println("Accept err", err)
			continue
		}

		fmt.Println("Accept Successed local addr is", conn.LocalAddr(), "remote addr is", conn.RemoteAddr())
		connectCount++
		if connectCount == 1 {
			startTime = time.Now().Unix()
			fmt.Println("server start time is", startTime)
		}

		if connectCount >= 1000 {
			endAcceptTime := time.Now().Unix()
			fmt.Println("end accept time is", endAcceptTime, "cost time is", endAcceptTime - startTime)
		}
		go handleConnection(conn)
	}
}

func handleConnection(conn net.Conn) {
	// 为这个连接开一个read协程 一个write协程
	go read(conn)
	go write(conn)
}

func read(conn net.Conn) {
	for {
		//buf, err := ioutil.ReadAll(conn)
		buf := make([]byte, 64)
		_, err := conn.Read(buf)
		if err != nil {
			fmt.Println("read err ...", err)
			conn.Close()
			return
		}
		fmt.Println("read successed buf is", string(buf))

	}
}

func write(conn net.Conn) {
	// 服务器暂时不写数据
	return
}
