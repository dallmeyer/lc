while read -r d; do
	d2=${d:0:${#d}-1}
	echo $d
	mkdir $d
	touch $d/$d.cs
done
