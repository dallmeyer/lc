#!/bin/bash

while read -r d; do
	echo $d
	mkdir $d
	touch $d/$d.cs
	touch $d/$d.py
	touch $d/$d.go
done
