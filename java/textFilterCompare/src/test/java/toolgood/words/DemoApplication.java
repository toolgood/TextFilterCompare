package toolgood.words;

import java.io.BufferedReader;
import java.io.File;
import java.io.FileReader;
import java.io.IOException;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

public class DemoApplication {
	public static void main(String[] args) throws Exception {
		test_WordsSearch_Time();
		test_WordsSearchEx_Time();
		test_AhoCorasickDoubleArrayTrie_Time();
	}
 
	public static void test_WordsSearch_Time() throws IOException {
		System.out.println("WordsSearch run Test.");

		List<String> keyArray=loadKeywords(new File("BadWord.txt"));
		String text =txt2String(new File("talk.txt"));

		WordsSearch iwords = new WordsSearch();
		iwords.SetKeywords(keyArray);

		long begintime = System.nanoTime();
		for (int i = 0; i < 100000; i++) {
			iwords.FindAll(text);
		}
		long endtime = System.nanoTime();
		long costTime = (endtime - begintime)/1000;

		System.out.println(costTime);


	}
	public static void test_WordsSearchEx_Time() throws IOException {
		System.out.println("WordsSearchEx run Test.");

		List<String> keyArray=loadKeywords(new File("BadWord.txt"));
		String text =txt2String(new File("talk.txt"));

		WordsSearchEx iwords = new WordsSearchEx();
		iwords.SetKeywords(keyArray);

		long begintime = System.nanoTime();
		for (int i = 0; i < 100000; i++) {
			iwords.FindAll(text);
		}
		long endtime = System.nanoTime();
		long costTime = (endtime - begintime)/1000;

		System.out.println(costTime);


	}
	public static void test_AhoCorasickDoubleArrayTrie_Time() throws IOException {
		System.out.println("AhoCorasickDoubleArrayTrie run Test.");

		List<String> keyArray=loadKeywords(new File("BadWord.txt"));
		String text =txt2String(new File("talk.txt"));


		Map<String, String> map = new HashMap<String, String>();
		for (String key : keyArray)
		{
			map.put(key, key);
		}
		AhoCorasickDoubleArrayTrie<String> acdat = new AhoCorasickDoubleArrayTrie<String>();
		acdat.build(map);

		long begintime = System.nanoTime();
		for (int i = 0; i < 100000; i++) {
			acdat.parseText(text);
		}
		long endtime = System.nanoTime();
		long costTime = (endtime - begintime)/1000;

		System.out.println(costTime);
	}

	public static List<String> loadKeywords(File file){
		List<String> keyArray=new ArrayList<String>();
		try{
			BufferedReader br = new BufferedReader(new FileReader(file));//构造一个BufferedReader类来读取文件
			String s = null;
			while((s = br.readLine())!=null){//使用readLine方法，一次读一行
				keyArray.add(s);
			}
			br.close();
		}catch(Exception e){
			e.printStackTrace();
		}
		return keyArray;
    }


	public static String txt2String(File file){
        StringBuilder result = new StringBuilder();
        try{
            BufferedReader br = new BufferedReader(new FileReader(file));//构造一个BufferedReader类来读取文件
            String s = null;
            while((s = br.readLine())!=null){//使用readLine方法，一次读一行
                result.append(System.lineSeparator()+s);
            }
            br.close();
        }catch(Exception e){
            e.printStackTrace();
        }
        return result.toString();
    }
}
