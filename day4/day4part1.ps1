$tc = cat .\input.txt
$counter=0;
$tc | % {$buff=""} {
    if ($_.Trim() -ne "") {
        $buff+= " "+$_.Trim()
    }
    else{
        $obj = @{}
        $buff.Trim().Split(" ") | % {
            $temp = $_.Trim().Split(":") 
                $obj[$temp[0]] = $temp[1]
        }
        if (($obj.Count -ge 7 -and !$obj["cid"]) -or $obj.Count -ge 8) {
            $counter++
        }
        $buff=""
    }
} {
    $obj = @{}
    $buff.Trim().Split(" ") | % {
        $temp = $_.Trim().Split(":") 
            $obj[$temp[0]] = $temp[1]
    }
    if (($obj.Count -ge 7 -and !$obj["cid"]) -or ($obj.Count -ge 8)) {
        $counter++
    }
}
$counter
