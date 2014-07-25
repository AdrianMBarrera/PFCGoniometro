public class Pose {
	
	private int art; 
	private int art1;
	public Vector bone; // posicion correcta del hueso
	public float grado; // restriccion en grados
	
	public Pose() {
		art = 0; art1 = 0; grado = 0;
		bone = new Vector();
	}		
	
	public void SetArt (int x) {art = x;}
	public void SetArt1 (int y) {art1 = y;}
	public void SetBone (Vector v) {bone = v;}
	public void SetGrado (float x) {grado = x;}
	
	public int GetArt() {return art;}
	public int GetArt1() {return art1;}
	public Vector GetBone() {return bone;}
	public float GetGrado() {return grado;}
}
